using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using Business;
using System.Web.Mvc.Ajax;

namespace System.Web.Mvc.Html
{
    //操作权限
    public static class PermissionExtensions
    {
        #region 操作权限

        public static bool CheckHasPermissions(ViewContext viewContext, string action, string controller = null, object routeValues = null)
        {
            //var session = HttpContext.Current.Session;

            var sessionLoginUser = HttpContext.Current.Session["SessionLoginUser"] as SessionLoginUser;
            if (sessionLoginUser == null)
            {
                return false;
            }
            controller = controller ?? viewContext.RequestContext.RouteData.Values["controller"] as string;
            action = action ?? viewContext.RequestContext.RouteData.Values["action"] as string;
            string area = null;
            if (routeValues != null)
            {
                var p = routeValues.GetType().GetProperty("Area");
                if (p != null)
                {
                    area = p.GetValue(routeValues, null) as string;
                }
            }
            if (sessionLoginUser.AccountType == 0 && sessionLoginUser.UserID == 1)
            {
                return true;//超级管理员
            }
            if (sessionLoginUser != null)
            {
                var menuModel = new MenuModel();
                return menuModel.CheckHasPermissions(sessionLoginUser.RoleIDs, action, controller, area);
            }
            return false;
        }

        public static MvcHtmlString ActionLink<TModel>(this HtmlHelper<TModel> htmlHelper, string linkText, string actionName, bool isCheckPermissions)
        {
            if (isCheckPermissions)
            {
                if (!CheckHasPermissions(htmlHelper.ViewContext, actionName))
                {
                    return MvcHtmlString.Empty;
                }
            }
            return htmlHelper.ActionLink(linkText, actionName);
        }

        public static MvcHtmlString ActionLink<TModel>(this HtmlHelper<TModel> htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes, bool isCheckPermissions, bool isShowText = false)
        {
            if (isCheckPermissions)
            {
                if (!CheckHasPermissions(htmlHelper.ViewContext, actionName, controllerName, routeValues))
                {
                    if (isShowText)
                    {
                        return MvcHtmlString.Create(linkText);
                    }
                    else
                    {
                        return MvcHtmlString.Empty;
                    }
                }
            }
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
        }

        public static MvcHtmlString ActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, bool isCheckPermissions, bool isShowText = false)
        {
            if (isCheckPermissions)
            {
                if (!CheckHasPermissions(ajaxHelper.ViewContext, actionName, controllerName, routeValues))
                {
                    if (isShowText)
                    {
                        return MvcHtmlString.Create(linkText);
                    }
                    else
                    {
                        return MvcHtmlString.Empty;
                    }
                }
            }
            return ajaxHelper.ActionLink(linkText, actionName, controllerName, routeValues, ajaxOptions);
        }

        #endregion
    }
}