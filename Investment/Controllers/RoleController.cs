using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Entity;

namespace Investment.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : BaseController
    {
        public ActionResult Index()
        {
            RoleModel roleModel = new RoleModel();
            var list = roleModel.List().ToList();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Role role)
        {
            RoleModel roleModel = new RoleModel();
            var result = roleModel.Add(role);

            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Role") + "'");
        }

        public ActionResult Edit(int id)
        {
            RoleModel roleModel = new RoleModel();
            var role = roleModel.Get(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(Role role)
        {
            RoleModel roleModel = new RoleModel();
            var result = roleModel.Edit(role);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Role") + "'");
        }

        public ActionResult Delete(int id)
        {
            RoleModel roleModel = new RoleModel();
            var result = roleModel.Delete(id);
            if (result.HasError)
            {
                return JavaScript("JMessage('" + result.Error + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Role") + "'");
        }

        /// <summary>
        /// 给角色分配操作权限
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleMenu(int id)
        {
            //获取当前角色
            RoleModel roleModel = new RoleModel();
            var role = roleModel.Get(id);
            ViewBag.Role = role;

            //获取所有菜单
            var menuModel = new MenuModel();
            var menus = menuModel.GetMenu();


            //当前角色所操作的菜单
            var currentRoleMenuList = menuModel.GetAllMenuByRoleID(id).Select(a => a.ID).ToList();
            ViewBag.CurrentRoleMenuList = currentRoleMenuList;

            //当前角色所操作的功能
            MenuOptionModel menuOptionModel = new MenuOptionModel();
            var currentRoleOptionList = menuOptionModel.GetAllOptionByRoleID(id).Select(a => a.ID).ToList();
            ViewBag.CurrentRoleOptionList = currentRoleOptionList;

            return View(menus);
        }


        [HttpPost]
        public ActionResult RoleMenu()
        {
            var roleID = Convert.ToInt32(Request["hidRoleID"]);
            var checkboxMenu = Request["checkboxMenu"];
            var checkboxOption = Request["checkboxOption"];

            int[] menuIDArray = null;
            if (!string.IsNullOrEmpty(checkboxMenu))
            {
                menuIDArray = checkboxMenu.Split(',').ConvertToIntArray();
            }

            int[] optionIDArray = null;
            if (!string.IsNullOrEmpty(checkboxOption))
            {
                optionIDArray = checkboxOption.Split(',').ConvertToIntArray();
            }
            try
            {
                RoleMenuModel roleMenuModel = new RoleMenuModel();
                roleMenuModel.BindPermission( roleID, menuIDArray, optionIDArray);
            }
            catch (Exception ex)
            {
                return JavaScript("JMessage('" + ex.Message + "',true)");
            }
            return JavaScript("window.location.href='" + Url.Action("Index", "Role") + "'");
        }
    }
}
