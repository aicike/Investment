using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class MenuModel : BaseModel<Menu>
    {
        /// <summary>
        /// 获取全部菜单
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetMenu()
        {
            return List().Where(a => a.ParentMenuID.HasValue == false).OrderBy(a => a.Order).ToList();
        }

        #region 菜单高亮显示使用
        public Menu GetMenuByControllerAction(string controller, string action)
        {
            return List().Where(a => a.Controller.Equals(controller, StringComparison.CurrentCultureIgnoreCase) &&
                a.Action.Equals(action, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        public Menu GetMenuByController(string controller)
        {
            return List().Where(a => a.Controller.Equals(controller, StringComparison.CurrentCultureIgnoreCase)).OrderBy(a=>a.ID).FirstOrDefault();
        }
        #endregion


        /// <summary>
        /// 根据角色获取菜单，有层级
        /// </summary>
        /// <param name="systemUserRoleID"></param>
        /// <param name="parentSystemUserMenuID"></param>
        /// <returns></returns>
        public List<Menu> GetMenuByRoleID(List<int> roleIDs, int? parentMenuID = null)
        {
            var list = List().ToList().Where(a => a.RoleMenus.Any(b => roleIDs.Contains(b.RoleID)) && a.ParentMenuID == parentMenuID).OrderBy(a => a.Order).ToList();
            foreach (var item in list)
            {
                item.Menus = item.Menus.Where(a => a.RoleMenus.Any(b => roleIDs.Contains(b.RoleID))).OrderBy(a => a.Order).ToList();
            }
            return list;
        }

        /// <summary>
        /// 获取菜单，有层级（集团超级管理员）
        /// </summary>
        /// <param name="systemUserRoleID"></param>
        /// <param name="parentSystemUserMenuID"></param>
        /// <returns></returns>
        public List<Menu> GetMenuForAdmin()
        {
            var list = List().ToList().Where(a => a.AccountType==0&& a.ParentMenuID.HasValue==false).OrderBy(a => a.Order).ToList();
            foreach (var item in list)
            {
                item.Menus = item.Menus.OrderBy(a => a.Order).ToList();
            }
            return list;
        }

        /// <summary>
        /// 检查操作权限
        /// </summary>
        public bool CheckHasPermissions(List<int> roleID, string action, string controller, string area)
        {
            //判断有没有权限操作当前菜单(Contorller)
            RoleMenuModel roleMenuModel = new RoleMenuModel(); ;

            var menu = roleMenuModel.List().Where(a => roleID.Contains(a.RoleID) &&
                                                       ((area != null && a.Menu.Area != null && a.Menu.Area.Equals(area, StringComparison.CurrentCultureIgnoreCase)) || (area == null && a.Menu.Area == null)) &&
                                                       (a.Menu.Controller != null && a.Menu.Controller.Equals(controller, StringComparison.CurrentCultureIgnoreCase))).Select(a => a.Menu).FirstOrDefault();

            if (menu == null) { return false; }

            //判断有没有权限操作当前功能(Action)
            RoleOptionModel roleOptionModel = new RoleOptionModel();
            var result = roleOptionModel.List().Any(a => roleID.Contains(a.RoleID) &&
                                                         a.MenuOption.MenuID == menu.ID &&
                                                         a.MenuOption.Action.Equals(action, StringComparison.CurrentCultureIgnoreCase));
            return result;
        }

        /// <summary>
        /// 根据角色id获取可操作的菜单，无级别限制
        /// </summary>
        public List<Menu> GetAllMenuByRoleID(int roleID)
        {
            var list = List().ToList().Where(a => a.RoleMenus.Any(b => b.RoleID == roleID)).OrderBy(a => a.Order).ToList();
            return list;
        }
    }
}
