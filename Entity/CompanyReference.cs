using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 客户借贷信息列表
    /// </summary>
    public class CompanyReference : BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        [Display(Name = "公司ID")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        [Display(Name = "借款金额")]
        [Required(ErrorMessage = "请输入借款金额")]
        public double Borrow { get; set; }

        /// <summary>
        /// 贷款方
        /// </summary>
        [Display(Name = "贷款方")]
        [Required(ErrorMessage = "请输入贷款方")]
        public string Lenders { get; set; }


        /// <summary>
        /// 借款期限
        /// </summary>
        [Display(Name = "借款期限")]
        [Required(ErrorMessage = "请输入借款期限")]
        public string Deadline { get; set; }

        /// <summary>
        /// 借款方式
        /// </summary>
        [Display(Name = "借款方式")]
        [Required(ErrorMessage = "请输入借款方式")]
        public string Methods { get; set; }

        /// <summary>
        /// 抵押物信息
        /// </summary>
        [Display(Name = "抵押物信息")]
        [Required(ErrorMessage = "请输入抵押物信息")]
        public string Collateral { get; set; }

        /// <summary>
        /// 担保方
        /// </summary>
        [Display(Name = "担保方")]
        [Required(ErrorMessage = "请输入担保方")]
        public string Sponsors { get; set; }


    }
}
