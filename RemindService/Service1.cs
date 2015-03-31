using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using Entity;
using Business.Commons;
using Business;

namespace RemindService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //没个1小时执行一次
            timer1.Interval = 10000;//3600000;
            timer1.Start();
        }

        protected override void OnStop()
        {
            timer1.Stop();
        }

        /// <summary>
        /// 定时执行 通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {

                string SendEmail = ConfigurationManager.AppSettings["sendEmail"].ToString();
                if (SendEmail == "True")
                {
                    // 提前一天提醒出纳放款（自有资金）
                    RemindCNFK();
                    // 放款后收利息提醒 （自有资金） 提前5天通知项目经理，如未收利息提前3天通知财务总监
                    RemindCNFKLX();
                    // 未填写日志题型
                    NotWriteWorkLog();

                }

            }
            catch { }
        }


        #region 流程定期提醒
        /// <summary>
        /// 提前一天提醒出纳放款（自有资金）
        /// </summary>
        public void RemindCNFK()
        {
            //System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(() =>
            //{
            WorkFlowModel wmodel = new WorkFlowModel();

            var workflowList = wmodel.List().Where(a => a.State == 2 && a.LoanDay != null && a.IsInterest == true && a.Financing.WorkFlowManagerID == 4 && a.IsSendEmail == false);
            //当前日期
            var NowDate = DateTime.Now;
            foreach (var item in workflowList)
            {
                var date = item.LoanDay.Value.Subtract(NowDate);
                //24小时内
                if (date.Days == 0 && date.Hours >= 0)
                {
                    //获取最后一节点的审批人（自有资金最后一节点为出纳）
                    var wfamanager = item.Financing.WorkFlowManager.WorkFlow_Node.OrderByDescending(a => a.Order).FirstOrDefault().WorkFlowApprovalManager.ToList();
                    //网站地址
                    var strUrl = System.Configuration.ConfigurationManager.AppSettings["URl"];
                    //内容
                    var content = "您好！<br/><br/>单号：" + item.Number + " 放款日期为:" + item.LoanDay.Value + ".<br/><br/>请您准备好放款！<br/><br/>点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看！<br/><br/>----陕西兆恒投资有限公司";
                    try
                    {
                        foreach (var Useritem in wfamanager)
                        {
                            //发邮件
                            SendEmails(Useritem.GroupAccount.Email, content);
                        }

                    }
                    catch { }
                    //更改状态 为已发邮件
                    wmodel.Upd_EmailType(item.ID);
                }
            }


            //});
            //t.Start();
        }

        /// <summary>
        /// 放款后收利息提醒 （自有资金） 提前5天通知项目经理，如未收利息提前3天通知财务总监
        /// </summary>
        public void RemindCNFKLX()
        {
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(() =>
            {
                //网站地址
                var strUrl = System.Configuration.ConfigurationManager.AppSettings["URl"];
                //当前日期
                var NowDate = DateTime.Now;
                InterestManagerModel IMmodel = new InterestManagerModel();
                //获取项目经理通知
                var interestJL = IMmodel.List().Where(a => a.IsCharge == false && a.WorkFlow.IsInterest == false && a.JLSendEmail == false);

                foreach (var item in interestJL)
                {
                    var date = item.EndDate.Subtract(NowDate);
                    //提前5天通知项目经理
                    if (date.Days == 4 && date.Hours >= 0)
                    {
                        var jlcontent = "您好！<br/><br/>单号：" + item.WorkFlow.Number + " 本次最后收取利息日期为:" + item.EndDate + ".<br/><br/> 如已收利息 请到系统中更改状态！<br/><br/>点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看！<br/><br/>----陕西兆恒投资有限公司";
                        //通知业务员
                        SendEmails(item.WorkFlow.Financing.Owner_A.Email, jlcontent);
                        //更改已发邮件状态
                        IMmodel.UpdJLSendEmail(item.ID);
                    }
                }
                //获取财务总监通知
                var interestZJ = IMmodel.List().Where(a => a.IsCharge == false && a.WorkFlow.IsInterest == false && a.CWZJSendEmail == false);
                foreach (var item in interestZJ)
                {
                    var date = item.EndDate.Subtract(NowDate);
                    //提前3天通知财务总监
                    if (date.Days == 2 && date.Hours >= 0)
                    {
                        var zjcontent = "您好！<br/><br/>单号：" + item.WorkFlow.Number + " 本次最后收取利息日期为:" + item.EndDate + ".<br/><br/> 请跟进！<br/><br/>点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看！<br/><br/>----陕西兆恒投资有限公司";
                        //通知财务总监
                        var cwzjEmail = System.Configuration.ConfigurationManager.AppSettings["cwzjEmail"];
                        SendEmails("", zjcontent);
                        //更改已发邮件状态
                        IMmodel.UpdCWZJSendEmail(item.ID);
                    }
                }
            });
            t.Start();
        }
        #endregion

        #region 未写日志题型

        private static DateTime writeWorkLogTime = DateTime.Now.Date;

        public void NotWriteWorkLog()
        {

            try
            {

                var days = DateTime.Now.Date.Subtract(writeWorkLogTime.Date).Days;
                if (days > 0)
                {
                    //第二天了
                    var zuoTian = DateTime.Now.AddDays(-1).Date;//昨天
                    RoleAccountModel ram = new RoleAccountModel();
                    var groupAccountIdsList = ram.List().Where(a => a.RoleID == 19).ToList();
                    if(groupAccountIdsList==null){
                        return;
                    }
                    var groupAccountIds=groupAccountIdsList.Select(a => a.GroupAccount.ID);     //所有有写日志权利的人员
                    GroupAccountModel gam = new GroupAccountModel();
                    List<string> emails = new List<string>();
                    WorkLogModel wflm = new WorkLogModel();
                    var zuoTianAccountIDsList = wflm.List().Where(a => a.LogDate.Date == zuoTian).ToList();//昨天写日志的人员
                    if(zuoTianAccountIDsList==null){
                        return;
                    }
                    var zuoTianAccountIDs =zuoTianAccountIDsList.Select(a => a.GroupAccountID);
                    if (zuoTianAccountIDs != null)
                    {
                        var notWriteAccountIDs = groupAccountIds.Where(a => zuoTianAccountIDs.Contains(a) == false).ToList();    //没有写日志的人员
                        emails = gam.List().Where(a => notWriteAccountIDs.Contains(a.ID)).Select(a => a.Email).ToList();      //获取email地址
                    }
                    else
                    {
                        emails = gam.List().Where(a => groupAccountIds.Contains(a.ID)).Select(a => a.Email).ToList();      //获取email地址
                    }
                    if (emails == null)
                    {
                        return;
                    }
                    var strUrl = System.Configuration.ConfigurationManager.AppSettings["URl"];
                    var jlcontent = "您好！<br/><br/>" + zuoTian.ToString("yyyy年MM月dd日") + "的工作日志还未填写，请及时完善。<br/><br/>点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看！<br/><br/>----陕西兆恒投资有限公司";
                    //通知业务员
                    foreach (var item in emails)
                    {
                        SendEmails(item, jlcontent);
                    }
                    writeWorkLogTime = DateTime.Now.Date;
                }
            }
            catch (Exception ex)
            {
                string exs = ex.Message;
            }
        }

        #endregion

        /// <summary>
        /// 发送邮件公共方法
        /// </summary>
        /// <param name="toEmail">收件人</param>
        /// <param name="Content">内容</param>
        public void SendEmails(string toEmail, string Content)
        {
            EmailInfo emailInfo = new EmailInfo();
            emailInfo.To = toEmail;
            emailInfo.Subject = "陕西兆恒投资业务管理系统";
            emailInfo.IsHtml = true;
            emailInfo.UseSSL = false;
            //var strUrl = System.Configuration.ConfigurationManager.AppSettings["URl"];
            emailInfo.Body = Content;// "您好！<br/><br/>您的陕西兆恒投资业务管理系统账号为：" + gAccount.AccountNumber + " <br/><br/>您的密码为：" + pwd + "<br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 选择集团登录，尽快更改密码！<br/><br/>----陕西兆恒投资有限公司";
            SendEmail.SendMailAsync(emailInfo);
        }



    }
}
