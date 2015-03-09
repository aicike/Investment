using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 贷款信息表
    /// </summary>
    public class FinancingHistory : BaseEntity
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }

        /// <summary>
        /// 项目负责人A角色
        /// </summary>
        public int? Owner_A_ID { get; set; }
        public virtual GroupAccount Owner_A { get; set; }

        /// <summary>
        /// 项目负责人B角色
        /// </summary>
        public int? Owner_B_ID { get; set; }
        public virtual GroupAccount Owner_B { get; set; }

        /// <summary>
        /// 贷款信息状态   0：未进行   1：进行中   2：已结束
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 贷款信息审核状态  -2:申请修改数据   -1：未提交申请   0：未审核   1：审核通过  2：审核不通过
        /// </summary>
        public int AuditStatus { get; set; }

        /// <summary>
        /// 贷款贷款主体
        /// </summary>
        [Display(Name = "贷款主体")]
        [Required(ErrorMessage = "请输入贷款主体")]
        public string Name { get; set; }

        /// <summary>
        /// 贷款金额
        /// </summary>
        [Display(Name = "贷款金额")]
        [Required(ErrorMessage = "请输入贷款金额")]
        public double Amount { get; set; }

        /// <summary>
        /// 贷款期限最小（单位：月）
        /// </summary>
        [Display(Name = "贷款期限")]
        [Required(ErrorMessage = "请输入贷款期限")]
        public int MinTimeLimit { get; set; }

        /// <summary>
        /// 贷款期限最大（单位：月）
        /// </summary>
        [Display(Name = "贷款期限")]
        [Required(ErrorMessage = "请输入贷款期限")]
        public int? MaxTimeLimit { get; set; }

        /// <summary>
        /// 收益率类型：0月  1年
        /// </summary>
        public int ShouYiLvType { get; set; }

        /// <summary>
        /// 贷款利率
        /// </summary>
        [Display(Name = "贷款利率")]
        [Required(ErrorMessage = "请输入贷款利率")]
        public double ShouYiLv { get; set; }

        /// <summary>
        /// 贷款用途
        /// </summary>
        [Display(Name = "贷款用途")]
        [Required(ErrorMessage = "请输入贷款用途")]
        public string Purpose { get; set; }

        /// <summary>
        /// 还款来源
        /// </summary>
        [Display(Name = "还款来源")]
        [Required(ErrorMessage = "请输入还款来源")]
        public string Repayment { get; set; }
        
        /// <summary>
        /// 抵押物清单
        /// </summary>
        [Display(Name = "抵押物清单")]
        [Required(ErrorMessage = "抵押物清单")]
        public string DiYaWuQingDan { get; set; }

        /// <summary>
        /// 担保措施
        /// </summary>
        [Display(Name = "担保措施")]
        [Required(ErrorMessage = "请输入担保措施")]
        public string ZengXinCuoShi { get; set; }

        /// <summary>
        /// 交易模式
        /// </summary>
        [Display(Name = "交易模式")]
        [Required(ErrorMessage = "请输入交易模式")]
        public string RongZiFangAn { get; set; }

        /// <summary>
        /// 项目现场核查
        /// </summary>
        [Display(Name = "项目现场核查")]
        public string Remark { get; set; }

        /// <summary>
        /// 业务来源
        /// </summary>
        [Required(ErrorMessage = "请输入业务来源")]
        public string BusinessResource { get; set; }

        /// <summary>
        /// 业务类型 0:未确定  1:自有资金  2:融资顾问
        /// </summary>
        [Required(ErrorMessage = "请输入业务类型")]
        public int BusinessType { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>
        [Display(Name = "项目类型")]
        public int? WorkFlowManagerID { get; set; }

        public virtual WorkFlowManager WorkFlowManager { get; set; }
        /// <summary>
        /// 流程表
        /// </summary>
        public virtual ICollection<WorkFlow> WorkFlow { get; set; }
    }
}
