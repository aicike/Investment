using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Role : BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 账号类型（0：集团   1：公司）
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Display(Name = "角色")]
        [Required(ErrorMessage = "请输入角色名称")]
        [StringLength(50, ErrorMessage = "不能超过50字")]
        public string RoleName { get; set; }
        
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }

        public virtual ICollection<RoleOption> RoleOptions { get; set; }

        public virtual ICollection<RoleAccount> RoleAccounts { get; set; }
    }
}
