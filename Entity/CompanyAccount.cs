using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 公司用户表
    /// </summary>
    public class CompanyAccount : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        [Display(Name = "公司ID")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        /// <summary>
        /// 登陆账号
        /// </summary>
        [Display(Name = "登录账号")]
        [Required(ErrorMessage = "请输入登录账号")]
        [StringLength(50, ErrorMessage = "列名不能超过50字")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string AccountPwd { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "请输入姓名")]
        [StringLength(50, ErrorMessage = "列名不能超过50字")]
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "请输入邮箱")]
        [StringLength(100, ErrorMessage = "邮箱不能超过100字")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "请输入有效的邮箱")]
        public string Email { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        [Display(Name = "头像地址")]
        public string HeadPortrait { get; set; }

        public virtual ICollection<RoleAccount> RoleAccounts { get; set; }
    }
}
