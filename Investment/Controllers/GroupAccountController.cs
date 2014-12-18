using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;
using Business.Commons;
using Investment.Controllers;

namespace Investment.Controllers
{
    /// <summary>
    /// 集团账号控制器
    /// </summary>
    public class GroupAccountController : BaseController
    {
        //
        // GET: /GroupAccount./
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            GroupAccountModel GAModel = new GroupAccountModel();
            var list = GAModel.List().Where(a => a.ID != 1).ToList();
            return View(list);
        }
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            RoleModel rModel = new RoleModel();
            ViewBag.Role = rModel.List().ToList();
            return View();
        }

        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(GroupAccount gAccount, string Roles)
        {
            GroupAccountModel gaModel = new GroupAccountModel();
            //校验
            if (gaModel.GetUnameIsOnly(gAccount.AccountNumber))
            {
                return JavaScript("JMessage('登陆账号已存在，请换一个试试！',true)");
            }
            Common Com = new Common();
            var pwd = Com.CreateRandom("", 6);
            gAccount.AccountPwd = DESEncrypt.Encrypt(pwd);
            gAccount.GroupID = 1;
            var result = gaModel.Add(gAccount);
            if (result.HasError == false)
            {
                if (Roles != "")
                {
                    //添加角色
                    RoleAccountModel raMoldel = new RoleAccountModel();
                    var strRoles = Roles.TrimEnd(',').Split(',');
                    foreach (string k in strRoles)
                    {
                        RoleAccount roleAccount = new RoleAccount();
                        roleAccount.RoleID = int.Parse(k);
                        roleAccount.GroupAccountID = gAccount.ID;
                        raMoldel.Add(roleAccount);
                    }
                }
                EmailInfo emailInfo = new EmailInfo();
                emailInfo.To = gAccount.Email;
                emailInfo.Subject = "陕西兆恒投资管理系统";
                emailInfo.IsHtml = true;
                emailInfo.UseSSL = false;

                var strUrl = System.Configuration.ConfigurationManager.AppSettings["URl"];
                emailInfo.Body = "您好！<br/><br/>您的陕西兆恒投资管理系统账号为：" + gAccount.AccountNumber + " <br/><br/>您的密码为：" + pwd + "<br/><br/>请点击<a href='" + strUrl + "'>华夏集团预算系统</a> 选择集团登陆，尽快更改密码！<br/><br/>----陕西兆恒投资有限公司";
                SendEmail.SendMailAsync(emailInfo);
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "GroupAccount") + "'");
        }

        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="GAID">集团用户ID</param>
        /// <returns></returns>
        public ActionResult Edit(int GAID)
        {
            GroupAccountModel gaModel = new GroupAccountModel();
            var Accountitem = gaModel.Get(GAID);
            RoleModel rModel = new RoleModel();
            ViewBag.Role = rModel.List().ToList();
            //获取角色
            RoleAccountModel raMoldel = new RoleAccountModel();
            ViewBag.RoleS = raMoldel.GetInfo_ByGAID(GAID).Select(a => a.RoleID).ToList();
            return View(Accountitem);
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="cAccount"></param>
        /// <param name="Roles"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(GroupAccount gAccount, string Roles)
        {
            GroupAccountModel gaModel = new GroupAccountModel();
            var result = gaModel.Edit(gAccount);
            if (result.HasError == false)
            {

                //修改角色
                RoleAccountModel raMoldel = new RoleAccountModel();
                raMoldel.Del_ByGAID(gAccount.ID);
                var strRoles = Roles.TrimEnd(',').Split(',');
                if (Roles != "")
                {
                    foreach (string k in strRoles)
                    {
                        RoleAccount roleAccount = new RoleAccount();
                        roleAccount.RoleID = int.Parse(k);
                        roleAccount.GroupAccountID = gAccount.ID;
                        raMoldel.Add(roleAccount);
                    }
                }
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "GroupAccount") + "'");
        }

        public ActionResult Delete(int GAID)
        {
            RoleAccountModel raMoldel = new RoleAccountModel();
            raMoldel.Del_ByGAID(GAID);
            GroupAccountModel gaModel = new GroupAccountModel();
            gaModel.Delete(GAID);
            return JavaScript("window.location.href='" + Url.Action("Index", "GroupAccount") + "'");
        }

    }
}
