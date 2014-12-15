using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class MenuOptionModel : BaseModel<MenuOption>
    {
        /// <summary>
        /// 根据当前角色id获取可操作的操作
        /// </summary>
        public List<MenuOption> GetAllOptionByRoleID(int roleID)
        {
            return List().Where(a => a.RoleOptions.Any(b =>b.RoleID == roleID)).ToList();
        }
    }
}
