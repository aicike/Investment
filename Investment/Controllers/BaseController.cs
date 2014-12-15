using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using System.Web.Routing;
using Business;

namespace Budget.Controllers
{
    public class BaseController : Controller
    {
        protected SessionLoginUser LoginAccount
        {
            get
            {
                var account = Session["SessionLoginUser"] as SessionLoginUser;
                return account;
            }
            set { Session["SessionLoginUser"] = value; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var controller = filterContext.RequestContext.RouteData.Values["controller"] as string;
            var action = filterContext.RequestContext.RouteData.Values["action"] as string;
            var area = filterContext.RouteData.DataTokens["area"] as string;

            //上一次请求信息
            string url = "";
            var request = filterContext.RequestContext.HttpContext.Request;
            if (request != null && request.UrlReferrer != null && request.UrlReferrer.AbsolutePath != null)
            {
                url = filterContext.RequestContext.HttpContext.Request.UrlReferrer.AbsoluteUri;
                ViewBag.BackUrl = url;
            }

            if (LoginAccount == null)
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new RouteValueDictionary{
                        { "controller", "Login" },
                        { "action", "Index" },
                        { "url",url}
                });
                return;
            }

            //权限
            var menuModel = new MenuModel();
            //menuModel.CheckHasPermissions(LoginAccount.RoleIDs, action, controller, area).NotAuthorizedPage();

            #region 设置当前Controller和Action，用来判断所在菜单是否高亮显示

            if (controller.Equals("Home", StringComparison.CurrentCultureIgnoreCase))
            {
                ViewBag.MenuID = 0;//首页
            }
            else
            {
                var menu = menuModel.GetMenuByControllerAction(controller, action);
                if (menu == null)
                {
                    menu = menuModel.GetMenuByController(controller);
                }
                if (menu != null)
                {
                    if (menu.IsShow.HasValue && menu.IsShow.Value == false)
                    {
                        ViewBag.MenuID = menu.ParentMenuID;//显示父级ID
                    }
                    else
                    {
                        ViewBag.MenuID = menu.ID;//查到，显示当前ID
                    }
                }
                else
                {
                    ViewBag.MenuID = 0;//没有查到，显示首页
                }
            }

            #endregion
            base.OnActionExecuting(filterContext);
        }

    }
}
