using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Menu : BaseEntity
    {
        public int ID { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "Controller")]
        public string Controller { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }

        /// <summary>
        /// 账号类型（0：集团   1：公司）
        /// </summary>
        public int AccountType { get; set; }

        [Display(Name = "描述")]
        [Required(ErrorMessage = "请输入描述")]
        [StringLength(20, ErrorMessage = "长度小于20")]
        [RegularExpression("^((?!<!).)*", ErrorMessage = "{0}中含有非法字符。")]
        public string Name { get; set; }

        [Display(Name = "显示名称")]
        [Required(ErrorMessage = "请输入显示名称")]
        [StringLength(20, ErrorMessage = "长度小于20")]
        [RegularExpression("^((?!<!).)*", ErrorMessage = "{0}中含有非法字符。")]
        public string ShowName { get; set; }

        public int Order { get; set; }

        public bool? IsShow { get; set; }

        public int? ParentMenuID { get; set; }
        public virtual Menu ParentMenu { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }

        public virtual ICollection<MenuOption> MenuOptions { get; set; }

        public virtual ICollection<RoleMenu> RoleMenus { get; set; }

    }
}
