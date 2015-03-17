using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 工作流程表
    /// </summary>
    public class WorkFlow : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 流程编号
        /// </summary>
        [Display(Name = "流程编号")]
        public string Number { get; set; }


        /// <summary>
        /// 贷款意向表ID
        /// </summary>
        [Display(Name = "贷款意向表ID")]
        public int FinancingID { get; set; }
        public virtual Financing Financing { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        /// <summary>
        /// 表单数据 JSON
        /// </summary>
        [Display(Name = "表单数据 JSON")]
        public string FormJson { get; set; }

        /// <summary>
        /// 项目负责人A角色(JSON)
        /// </summary>
        public int? JSON_Owner_A_ID { get; set; }
        public virtual GroupAccount JSON_Owner_A { get; set; }

        /// <summary>
        /// 项目负责人B角色(JSON)
        /// </summary>
        public int? JSON_Owner_B_ID { get; set; }
        public virtual GroupAccount JSON_Owner_B { get; set; }

        /// <summary>
        /// 状态 0草稿，1进行中，2已完成，3未通过
        /// </summary>
        [Display(Name = "状态")]
        public int State { get; set; }

        /// <summary>
        /// 流程申请时间
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// 流程结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 当前节点ID（流程与节点中间表）
        /// </summary>
        [Display(Name = "当前节点（流程与节点中间表）")]
        public int? WorkFlow_NodeID { get; set; }
        public virtual WorkFlow_Node WorkFlow_Node { get; set; }

        /// <summary>
        /// 放款日期
        /// </summary>
        public DateTime? LoanDay { get; set; }

        /// <summary>
        /// 是否已收利息
        /// </summary>
        public bool IsInterest { get; set; }

        /// <summary>
        /// 是否已发邮件
        /// </summary>
        public bool IsSendEmail { get; set; }

        //-------------子表----------------------------
        /// <summary>
        /// 审批记录表
        /// </summary>
        public virtual ICollection<ApprovalRecord> ApprovalRecord { get; set; }

        /// <summary>
        /// 流程对应产品信息表
        /// </summary>
        public virtual ICollection<WorkFlowMechanismProduct> WorkFlowMechanismProduct { get; set; }

        /// <summary>
        /// 工作日志
        /// </summary>
        public virtual ICollection<WorkLog> WorkLogs { get; set; }

        /// <summary>
        /// 利息表（自有）
        /// </summary>
        public virtual ICollection<Interest> Interest { get; set; }
    }
}
