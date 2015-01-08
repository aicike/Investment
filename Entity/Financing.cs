using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 融资信息表
    /// </summary>
    public class Financing : BaseEntity
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }

        /// <summary>
        /// 融资项目名称
        /// </summary>
        [Display(Name = "项目名称")]
        [Required(ErrorMessage = "请输入项目名称")]
        public string Name { get; set; }

        /// <summary>
        /// 融资金额
        /// </summary>
        [Display(Name = "融资金额")]
        [Required(ErrorMessage = "请输入融资金额")]
        public double Amount { get; set; }

        /// <summary>
        /// 融资期限最小（单位：月）
        /// </summary>
        [Display(Name = "融资期限")]
        [Required(ErrorMessage = "请输入融资期限")]
        public int MinTimeLimit { get; set; }

        /// <summary>
        /// 融资期限最大（单位：月）
        /// </summary>
        [Display(Name = "融资期限")]
        [Required(ErrorMessage = "请输入融资期限")]
        public int? MaxTimeLimit { get; set; }

        /// <summary>
        /// 收益率类型：0月  1年
        /// </summary>
        public int ShouYiLvType { get; set; }

        /// <summary>
        /// 收益率
        /// </summary>
        [Display(Name = "收益率")]
        [Required(ErrorMessage = "请输入收益率")]
        public double ShouYiLv { get; set; }

        /// <summary>
        /// 融资成本
        /// </summary>
        [Display(Name = "融资成本")]
        [Required(ErrorMessage = "请输入融资成本")]
        public double FinancingCost { get; set; }

        /// <summary>
        /// 融资用途
        /// </summary>
        [Display(Name = "融资用途")]
        [Required(ErrorMessage = "请输入融资用途")]
        public string Purpose { get; set; }

        /// <summary>
        /// 还款来源
        /// </summary>
        [Display(Name = "还款来源")]
        [Required(ErrorMessage = "请输入还款来源")]
        public string Repayment { get; set; }

        /// <summary>
        /// 融资标的
        /// </summary>
        public string RongZiBiaoDi { get; set; }

        /// <summary>
        /// 增信措施
        /// </summary>
        [Display(Name = "增信措施")]
        [Required(ErrorMessage = "请输入增信措施")]
        public string ZengXinCuoShi { get; set; }

        /// <summary>
        /// 融资方案
        /// </summary>
        [Display(Name = "融资方案")]
        [Required(ErrorMessage = "请输入融资方案")]
        public string RongZiFangAn { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }


        //-----------------子表
        /// <summary>
        /// 流程表
        /// </summary>
        public virtual ICollection<WorkFlow> WorkFlow { get; set; }
    }
}
