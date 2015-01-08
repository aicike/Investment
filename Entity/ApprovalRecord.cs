using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 审批记录表
    /// </summary>
    public class ApprovalRecord : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 流程表ID
        /// </summary>
        [Display(Name = "流程表ID")]
        public int WorkFlowID { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }

        /// <summary>
        /// 审批人ID
        /// </summary>
        [Display(Name = "审批人ID")]
        public int GroupAccountID { get; set; }
        public virtual GroupAccount GroupAccount { get; set; }


        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 审批人名称
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 审批人角色
        /// </summary>
        public string AccountPosition { get; set; }

         /// <summary>
        /// 审批意见
        /// </summary>
        public string Opinion { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        public DateTime Date { get; set; }
    }
}
