using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 集团主表
    /// </summary>
    public class Group : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 集团名称
        /// </summary>
        [Display(Name = "集团名称")]
        [Required(ErrorMessage = "请输入集团名称")]
        [StringLength(100, ErrorMessage = "列名不能超过100字")]
        public string Name { get; set; }


        //----------------------子表------------------------------------------
        /// <summary>
        /// 集团用户表
        /// </summary>
        public virtual ICollection<GroupAccount> GroupAccount { get; set; }
        /// <summary>
        /// 公司表
        /// </summary>
        public virtual ICollection<Company> Company { get; set; }
    }
}
