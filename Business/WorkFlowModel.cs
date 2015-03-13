using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Transactions;
using System.Data.Entity;
using System.Threading.Tasks;
using Business.Commons;

namespace Business
{
    /// <summary>
    /// 工作流程表 Model
    /// </summary>
    public class WorkFlowModel : BaseModel<WorkFlow>
    {
        //申请表单锁
        private static object LockObj = new object();
        /// <summary>
        /// 根据负责人ID 和 状态 获取列表
        /// </summary>
        /// <param name="state">状态 0草稿，1进行中，2已完成，3未通过</param>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetListByState(int state, int groupAccountID)
        {
            return List().Where(a => a.State == state && a.Financing.Owner_A_ID == groupAccountID);
        }

        /// <summary>
        /// 我的申请
        /// </summary>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetMyApplication(int groupAccountID)
        {
            var list = List().Where(a => (a.Financing.Owner_A_ID == groupAccountID||a.JSON_Owner_A_ID==groupAccountID) && a.State != 0).Distinct().OrderByDescending(a => a.ID);//包含实时数据和JSON数据

            return list;
        }

        /// <summary>
        /// 我的待办
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetBacklog(int groupAccountID)
        {
            var list = List().Where(a => a.ApprovalRecord.Any(b => b.Operation == -1 && b.GroupAccountID == groupAccountID));
            return list;
        }

        /// <summary>
        /// 我的已办
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetHistory(int groupAccountID)
        {
            var list = List().Where(a => a.ApprovalRecord.Any(b => (b.Operation == 1 || b.Operation == 2 || b.Operation == 3) && b.GroupAccountID == groupAccountID));
            return list;
        }

        /// <summary>
        /// 我的辅助
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetAssist(int groupAccountID)
        {
            var list = List().Where(a => a.Financing.Owner_B_ID == groupAccountID || a.JSON_Owner_B_ID == groupAccountID).Distinct().OrderByDescending(a => a.ID);
            return list;
        }

        /// <summary>
        /// 项目列表
        /// </summary>
        /// <param name="groupAccountID"></param>
        /// <returns></returns>
        public IQueryable<WorkFlow> GetList()
        {
            var list = List().Where(a => a.State != 0);
            return list;
        }


        /// <summary>
        /// 根据流程ID获取 贷款信息、公司信息的 json数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get_To_Json_Financing(int id)
        {
            var obj = Get(id);//工作流程表

            base.Context.Configuration.ProxyCreationEnabled = false;

            var financing = base.Context.Financings.Where(a => a.ID == obj.FinancingID).AsNoTracking().FirstOrDefault();//贷款信息

            var company = base.Context.Company.Where(a => a.ID == obj.Financing.CompanyID).AsNoTracking().FirstOrDefault(); //公司信息

            //var wfmpIDs = obj.WorkFlowMechanismProduct.Select(a => a.MechanismProductsID).ToList();
            //base.Context.MechanismProducts.Where(a => wfmpIDs.Contains(a.ID));//机构产品信息

            var workFlowManager = base.Context.WorkFlowManager.Where(a => a.ID == obj.Financing.WorkFlowManagerID).AsNoTracking().FirstOrDefault(); //流程类型

            var owner_a = base.Context.GroupAccount.Where(a => a.ID == obj.Financing.Owner_A_ID).AsNoTracking().FirstOrDefault(); //A角

            var owner_b = base.Context.GroupAccount.Where(a => a.ID == obj.Financing.Owner_B_ID).AsNoTracking().FirstOrDefault(); //A角

            financing.Company = company;
            financing.WorkFlowManager = workFlowManager;
            financing.Owner_A = owner_a;
            financing.Owner_B = owner_b;

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(financing);
            return json;
        }

        /// <summary>
        /// 根据流程ID 存储产品快照
        /// </summary>
        /// <param name="WorkFlowID">流程ID</param>
        /// <returns></returns>
        public Result Get_To_Json_Product(int WorkFlowID)
        {
            Result result = new Result();
            //获取流程中选择的机构
            WorkFlowMechanismProductModel WFMPModel = new WorkFlowMechanismProductModel();
            WFMPModel.Context.Configuration.ProxyCreationEnabled = false;
            var wfmps = WFMPModel.GetInfo_ByWorkFlowID(WorkFlowID);
            MechanismProductsModel mpModel = new MechanismProductsModel();
            mpModel.Context.Configuration.ProxyCreationEnabled = false;
            //生成快照
            foreach (var item in wfmps)
            {
                var mp = mpModel.Get(item.MechanismProductsID);
                item.FormJson = Newtonsoft.Json.JsonConvert.SerializeObject(mp);
                WFMPModel.Edit(item);
            }
            return result;
        }

        /// <summary>
        /// 提交申请
        /// </summary>
        /// <param name="WorkFlowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <returns></returns>
        public Result SubWorkFlow(int WorkFlowID, int GroupAccountID)
        {
            Result result = new Result();
            lock (LockObj)
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //获取流程信息
                    var workflow = base.Get(WorkFlowID);
                    //生成单号
                    Commons.Common com = new Commons.Common();
                    var number = com.SqlQuery<string>("select dbo.GetWorkFlowNumber('ZH',3)");
                    workflow.Number = number.FirstOrDefault();
                    workflow.State = 1;
                    workflow.IsInterest = false;
                    //查找下一节点
                    WorkFlow_NodeModel w_nModel = new WorkFlow_NodeModel();
                    var workflow_node = w_nModel.Getwork_node(workflow.Financing.WorkFlowManagerID.Value, 2);
                    if (workflow_node == null)
                    {
                        result.HasError = true;
                        result.Error = "该流程尚未配置！";
                        return result;
                    }
                    workflow.WorkFlow_NodeID = workflow_node.ID;
                    base.Edit(workflow);
                    //添加审批记录
                    ApprovalRecordModel ARModel = new ApprovalRecordModel();
                    ApprovalRecord approvalrecord = new ApprovalRecord();
                    approvalrecord.AccountName = workflow.Financing.Owner_A.Name;
                    approvalrecord.AccountPosition = "项目经理";
                    approvalrecord.Date = DateTime.Now;
                    approvalrecord.GroupAccountID = GroupAccountID;
                    approvalrecord.NodeName = "提交业务申请";
                    approvalrecord.Operation = 0;
                    approvalrecord.Opinion = "";
                    approvalrecord.WorkFlowID = WorkFlowID;
                    ARModel.Add(approvalrecord);
                    //添加下一节点审批人记录
                    ARModel.AddunapprovedInfo(workflow_node, WorkFlowID);
                    //更改贷款意向状态
                    FinancingModel FModel = new FinancingModel();
                    var financing = FModel.Get(workflow.FinancingID);
                    financing.Status = 1;
                    FModel.Edit(financing);

                    scope.Complete();
                }

                //邮件通知
                EmailApprovalNotice(WorkFlowID, 5, "");
            }
            return result;
        }

        /// <summary>
        /// 审批通过公共方法
        /// </summary>
        /// <param name="WorkFlowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <param name="Content">审批意见</param>
        /// <returns></returns>
        public Result WorkFlow_Agree(int WorkFlowID, int GroupAccountID, string Content)
        {
            Result result = new Result();
            ApprovalRecordModel ARModel = new ApprovalRecordModel();
            //获取流程信息
            var workflow = base.Get(WorkFlowID);
            var IsOver = false;
            using (TransactionScope scope = new TransactionScope())
            {

                //更新审批记录
                ARModel.UPDApprovedInfo(WorkFlowID, GroupAccountID, Content, 1);
                //判断当前节点是否审批完成
                IsOver = ARModel.JudgeThisNodeIsOver(WorkFlowID);

                WorkFlow_NodeModel w_nModel = new WorkFlow_NodeModel();
                if (!IsOver)
                {
                    //查找下一节点
                    var Nextworkflow_node = w_nModel.GetNextWorkFlow_Node(workflow.Financing.WorkFlowManagerID.Value, workflow.WorkFlow_NodeID.Value);
                    //流程结束
                    if (Nextworkflow_node == null)
                    {
                        //更改贷款意向状态
                        FinancingModel FModel = new FinancingModel();
                        var financing = FModel.Get(workflow.FinancingID);
                        financing.Status = 2;
                        FModel.Edit(financing);
                        //更改流程状态
                        workflow.State = 2;//已完成
                        //生成意向快照
                        workflow.FormJson = Get_To_Json_Financing(WorkFlowID);
                        workflow.JSON_Owner_A_ID = financing.Owner_A_ID;
                        workflow.JSON_Owner_B_ID = financing.Owner_B_ID;
                        base.Edit(workflow);
                        //生成产品快照
                        Get_To_Json_Product(WorkFlowID);

                    }
                    else
                    {
                        //更改下一流程节点
                        workflow.WorkFlow_NodeID = Nextworkflow_node.ID;
                        base.Edit(workflow);
                        //添加下一节点审批人记录
                        ARModel.AddunapprovedInfo(Nextworkflow_node, WorkFlowID);
                    }
                }
                scope.Complete();

            }
            if (workflow.State == 2)
            {
                //邮件通知 流程结束
                EmailApprovalNotice(WorkFlowID, 4, "");
            }
            else
            {
                if (IsOver)
                {
                    //邮件通知
                    EmailApprovalNotice(WorkFlowID, 1, "");
                }

            }
            return result;
        }

        /// <summary>
        /// 审批不通过公共方法
        /// </summary>
        /// <param name="WorkFlowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <param name="Content">审批意见</param>
        /// <returns></returns>
        public Result WorkFlow_Disagree(int WorkFlowID, int GroupAccountID, string Content)
        {
            Result result = new Result();
            ApprovalRecordModel ARModel = new ApprovalRecordModel();
            //获取流程信息
            var workflow = base.Get(WorkFlowID);
            var userEmail = workflow.Financing.Owner_A.Email;
            using (TransactionScope scope = new TransactionScope())
            {

                //更新流程状态
                workflow.State = 3;
                //生成意向快照
                workflow.FormJson = Get_To_Json_Financing(WorkFlowID);
                base.Edit(workflow);
                //生成产品快照
                Get_To_Json_Product(WorkFlowID);
                //更新审批记录
                ARModel.UPDApprovedInfo(WorkFlowID, GroupAccountID, Content, 2);
                //删除多余记录
                ARModel.DelunapprovedInfo(WorkFlowID);
                //更改贷款意向状态
                FinancingModel FModel = new FinancingModel();
                var financing = FModel.Get(workflow.FinancingID);
                financing.Status = 0;
                FModel.Edit(financing);

                scope.Complete();
                //邮件通知
            }

            EmailApprovalNotice(WorkFlowID, 2, userEmail);
            return result;
        }

        /// <summary>
        /// 驳回公共方法
        /// </summary>
        /// <param name="WorkFlowID">工作流ID</param>
        /// <param name="GroupAccountID">审批人ID</param>
        /// <param name="WorkFlow_NodeID">驳回到的节点ID</param>
        /// <param name="Content">审批意见</param>
        /// <returns></returns>
        public Result WorkFlow_Reject(int WorkFlowID, int GroupAccountID, int WorkFlow_NodeID, string Content)
        {
            Result result = new Result();
            using (TransactionScope scope = new TransactionScope())
            {
                ApprovalRecordModel ARModel = new ApprovalRecordModel();
                //获取流程信息
                var workflow = base.Get(WorkFlowID);
                //更新流程节点
                workflow.WorkFlow_NodeID = WorkFlow_NodeID;
                base.Edit(workflow);
                //更新审批记录
                ARModel.UPDApprovedInfo(WorkFlowID, GroupAccountID, Content, 3);
                //删除多余记录
                ARModel.DelunapprovedInfo(WorkFlowID);
                //添加下一节点审批人记录
                WorkFlow_NodeModel w_nModel = new WorkFlow_NodeModel();
                var Nextworkflow_node = w_nModel.Get(WorkFlow_NodeID);
                ARModel.AddunapprovedInfo(Nextworkflow_node, WorkFlowID);
                scope.Complete();
            }

            //邮件通知
            EmailApprovalNotice(WorkFlowID, 3, "");
            return result;
        }

        /// <summary>
        /// 查询该意向是否生成待定单或已提交申请
        /// </summary>
        /// <param name="FinancingID"></param>
        /// <returns>true 已生成</returns>
        public Result GetISCreatePending(int FinancingID)
        {
            Result result = new Result();
            var item = List().Where(a => a.FinancingID == FinancingID).FirstOrDefault();
            if (item != null)
            {
                if (item.State == 0)
                {
                    result.HasError = true;
                    result.Error = "此业务已生成待定业务，请在‘待定业务’中查看";
                }
                else if (item.State == 1)
                {
                    result.HasError = true;
                    result.Error = "此业务正在审批中，请在‘我的申请’中查看";
                }
                else if (item.State == 2)
                {
                    result.HasError = true;
                    result.Error = "此业务已完成业务流程，请在‘我的申请’中查看";
                }
            }
            return result;
        }

        /// <summary>
        /// 邮件审批通知
        /// </summary>
        /// <param name="workflowID"></param>
        /// <param name="type">1 通过 2 不通过 3 驳回 4通过流程结束 5流程提交</param>
        /// <param name="email">不通过时 传入收件人邮件地址</param>
        /// <returns></returns>
        public Result EmailApprovalNotice(int workflowID, int type, string email)
        {
            Result result = new Result();
            var sendEmail = System.Configuration.ConfigurationManager.AppSettings["sendEmail"];
            if (sendEmail == "True")
            {


                try
                {
                    var workflow = base.Get(workflowID);
                    ApprovalRecordModel ARModel = new ApprovalRecordModel();
                    WorkFlow_NodeModel w_nModel = new WorkFlow_NodeModel();
                    EmailInfo emailInfo;
                    var strUrl = System.Configuration.ConfigurationManager.AppSettings["URl"];
                    Task t = new Task(() =>
                    {
                        switch (type)
                        {
                            case 1: //通过
                                //查找最后审批通过的节点
                                var workflow_node = w_nModel.GetLastWorkFlow_Node(workflow.Financing.WorkFlowManagerID.Value, workflow.WorkFlow_NodeID.Value);
                                //通知申请人
                                emailInfo = new EmailInfo();
                                emailInfo.To = workflow.Financing.Owner_A.Email;
                                emailInfo.Subject = "流程审批通知（通过）--陕西兆恒投资业务管理系统";
                                emailInfo.IsHtml = true;
                                emailInfo.UseSSL = false;

                                emailInfo.Body = "您好！<br/><br/>您申请的业务：" + workflow.Number + "。" + workflow_node.WorkFlowNodeManager.Name + "节点已审批<span style='color:Green'>通过</span>。 <br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                SendEmail.SendMailAsync(emailInfo);
                                //通知审批人

                                //自审批
                                if (workflow.WorkFlow_Node.IsSinceApproval)
                                {
                                    emailInfo = new EmailInfo();
                                    emailInfo.To = workflow.Financing.Owner_A.Email;
                                    emailInfo.Subject = "流程审批通知--陕西兆恒投资业务管理系统";
                                    emailInfo.IsHtml = true;
                                    emailInfo.UseSSL = false;

                                    emailInfo.Body = "您好！<br/><br/>您有一个新的业务：" + workflow.Number + "。等待您的审批<br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                    SendEmail.SendMailAsync(emailInfo);
                                }
                                else
                                {
                                    foreach (var item in workflow.WorkFlow_Node.WorkFlowApprovalManager)
                                    {
                                        emailInfo = new EmailInfo();
                                        emailInfo.To = item.GroupAccount.Email;
                                        emailInfo.Subject = "流程审批通知--陕西兆恒投资业务管理系统";
                                        emailInfo.IsHtml = true;
                                        emailInfo.UseSSL = false;

                                        emailInfo.Body = "您好！<br/><br/>您有一个新的业务：" + workflow.Number + "。等待您的审批<br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                        SendEmail.SendMailAsync(emailInfo);
                                    }
                                }
                                break;
                            case 2: //不通过

                                emailInfo = new EmailInfo();
                                emailInfo.To = email;
                                emailInfo.Subject = "流程审批通知（不通过）--陕西兆恒投资业务管理系统";
                                emailInfo.IsHtml = true;
                                emailInfo.UseSSL = false;

                                emailInfo.Body = "您好！<br/><br/>您申请的业务：" + workflow.Number + "。审批<span style='color:red'>未通过</span>。流程已结束 <br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                SendEmail.SendMailAsync(emailInfo);
                                break;
                            case 3: //驳回
                                //通知申请人
                                emailInfo = new EmailInfo();
                                emailInfo.To = workflow.Financing.Owner_A.Email;
                                emailInfo.Subject = "流程审批通知（驳回）--陕西兆恒投资业务管理系统";
                                emailInfo.IsHtml = true;
                                emailInfo.UseSSL = false;

                                emailInfo.Body = "您好！<br/><br/>您申请的业务：" + workflow.Number + "。被<span style='color:blue'>驳回</span>。 <br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                SendEmail.SendMailAsync(emailInfo);
                                //通知审批人

                                //自审批
                                if (workflow.WorkFlow_Node.IsSinceApproval)
                                {
                                    emailInfo = new EmailInfo();
                                    emailInfo.To = workflow.Financing.Owner_A.Email;
                                    emailInfo.Subject = "流程审批通知--陕西兆恒投资业务管理系统";
                                    emailInfo.IsHtml = true;
                                    emailInfo.UseSSL = false;

                                    emailInfo.Body = "您好！<br/><br/>您有一个新的业务：" + workflow.Number + "。等待您的审批<br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                    SendEmail.SendMailAsync(emailInfo);
                                }
                                else
                                {
                                    foreach (var item in workflow.WorkFlow_Node.WorkFlowApprovalManager)
                                    {
                                        emailInfo = new EmailInfo();
                                        emailInfo.To = item.GroupAccount.Email;
                                        emailInfo.Subject = "流程审批通知--陕西兆恒投资业务管理系统";
                                        emailInfo.IsHtml = true;
                                        emailInfo.UseSSL = false;

                                        emailInfo.Body = "您好！<br/><br/>您有一个新的业务：" + workflow.Number + "。等待您的审批<br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                        SendEmail.SendMailAsync(emailInfo);
                                    }
                                }
                                break;
                            case 4: //流程结束 通过
                                //通知申请人
                                emailInfo = new EmailInfo();
                                emailInfo.To = workflow.Financing.Owner_A.Email;
                                emailInfo.Subject = "流程审批通知（通过 流程完成）--陕西兆恒投资业务管理系统";
                                emailInfo.IsHtml = true;
                                emailInfo.UseSSL = false;

                                emailInfo.Body = "您好！<br/><br/>您申请的业务：" + workflow.Number + "。已审批<span style='color:Green'>通过</span>。 <br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                SendEmail.SendMailAsync(emailInfo);
                                break;
                            case 5:
                                //自审批
                                if (workflow.WorkFlow_Node.IsSinceApproval)
                                {
                                    emailInfo = new EmailInfo();
                                    emailInfo.To = workflow.Financing.Owner_A.Email;
                                    emailInfo.Subject = "流程审批通知--陕西兆恒投资业务管理系统";
                                    emailInfo.IsHtml = true;
                                    emailInfo.UseSSL = false;

                                    emailInfo.Body = "您好！<br/><br/>您有一个新的业务：" + workflow.Number + "。等待您的审批<br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                    SendEmail.SendMailAsync(emailInfo);
                                }
                                else
                                {
                                    foreach (var item in workflow.WorkFlow_Node.WorkFlowApprovalManager)
                                    {
                                        emailInfo = new EmailInfo();
                                        emailInfo.To = item.GroupAccount.Email;
                                        emailInfo.Subject = "流程审批通知--陕西兆恒投资业务管理系统";
                                        emailInfo.IsHtml = true;
                                        emailInfo.UseSSL = false;

                                        emailInfo.Body = "您好！<br/><br/>您有一个新的业务：" + workflow.Number + "。等待您的审批<br/><br/>请点击<a href='" + strUrl + "'>兆恒投资业务管理系统</a> 登录查看<br/><br/>----陕西兆恒投资有限公司";
                                        SendEmail.SendMailAsync(emailInfo);
                                    }
                                }
                                break;
                        }
                    });

                    t.Start();
                }
                catch
                {

                }
            }
            return result;
        }

        /// <summary>
        /// 更改放款日期
        /// </summary>
        /// <param name="workflowID"></param>
        /// <param name="FKRI"></param>
        /// <returns></returns>
        public Result Upd_FKRI(int workflowID, string FKRI)
        {
            Result result = new Result();
            string sql = string.Format("update workflow set LoanDay ='{0}'  where id = {1}",FKRI,workflowID);
            base.SqlExecute(sql);
            return result;
        }

        
    }
}
