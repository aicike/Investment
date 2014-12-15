using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Budget.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            // 请求上次存储的Cookies
            HttpCookie cookies = Request.Cookies["USER_COOKIE"];
            // 如果此Cookies存在且它里面有子键则进行读取
            if (cookies != null && cookies.HasKeys)
            {
                string username = DESEncrypt.Decrypt(cookies["Name"]);
                string password = DESEncrypt.Decrypt(cookies["Pwd"]);
                int role = int.Parse(cookies["Role"]);
                Result result = Login(role, username, password);
                if (!result.HasError)
                {
                    return RedirectToAction("Home", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password, int role, int remember = 0)
        {
            var result = Login(role, username, password);
            if (result.HasError)
            {
                var data = new { hasError = true, error = result.Error };
                return Json(data);
            }
            else
            {
                if (remember==1)
                {

                    // 设置 Cookie 信息
                    HttpCookie cookie = new HttpCookie("USER_COOKIE");
                    // 设置用户昵称、密码
                    cookie.Values.Add("Name", DESEncrypt.Encrypt(username));
                    cookie.Values.Add("Pwd", DESEncrypt.Encrypt(password));
                    cookie.Values.Add("Role", role + "");

                    // 令 Cookie 永不过期
                    cookie.Expires = System.DateTime.Now.AddDays(7.0);

                    // 保存用户的 Cookie
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    if (Response.Cookies["USER_COOKIE"] != null)
                    {
                        Response.Cookies["USER_COOKIE"].Expires = DateTime.Now;
                    }
                }
                var data = new { hasError = false };
                return Json(data);
            }
        }

        /// <summary>
        /// 处理登录方法
        /// </summary>
        private Result Login(int role, string username, string password)
        {
            Result result = null;
            SessionLoginUser sessionLoginUser = null;
            switch (role)
            {
                case 1:
                    CompanyAccountModel cam = new CompanyAccountModel();
                    result = cam.Login(username, password);
                    if (result.HasError == false)
                    {
                        sessionLoginUser = new SessionLoginUser();
                        var ca = result.Entity as CompanyAccount;
                        sessionLoginUser.ID = ca.CompanyID;
                        sessionLoginUser.UserID = ca.ID;
                        sessionLoginUser.CompanyName = ca.Company.Name;
                        sessionLoginUser.UserName = ca.Name;
                        sessionLoginUser.AccountType = 1;
                        sessionLoginUser.RoleIDs = ca.RoleAccounts.Select(a => a.RoleID).ToList();
                        Session["SessionLoginUser"] = sessionLoginUser;
                    }
                    break;
                case 2:
                    GroupAccountModel gam = new GroupAccountModel();
                    result = gam.Login(username, password);
                    if (result.HasError == false)
                    {
                        sessionLoginUser = new SessionLoginUser();
                        var ga = result.Entity as GroupAccount;
                        sessionLoginUser.ID = ga.GroupID;
                        sessionLoginUser.CompanyName = ga.Group.Name;
                        sessionLoginUser.UserName = ga.Name;
                        sessionLoginUser.UserID = ga.ID;
                        sessionLoginUser.AccountType = 0;
                        sessionLoginUser.RoleIDs = ga.RoleAccounts.Select(a => a.RoleID).ToList();
                        Session["SessionLoginUser"] = sessionLoginUser;
                    }
                    break;
            }
            return result;
        }
    }
}
