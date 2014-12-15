using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 公司主表
    /// </summary>
    public class Company : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 集团ID
        /// </summary>
        [Display(Name = "集团ID")]
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Display(Name = "公司名称")]
        [Required(ErrorMessage = "请输入公司名称")]
        [StringLength(100, ErrorMessage = "列名不能超过100字")]
        public string Name { get; set; }


        //----------------------子表------------------------------------------
        /// <summary>
        /// 公司用户表
        /// </summary>
        public virtual ICollection<CompanyAccount> CompanyAccount { get; set; }

    }
}
