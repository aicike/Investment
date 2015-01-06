using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 流程节点审批管理
    /// </summary>
    public class WorkFlowApprovalManager:BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 流程主表用节点中间表ID
        /// </summary>
        [Display(Name = "流程ID")]
        public int WorkFlow_NodeID { get; set; }
        public virtual WorkFlow_Node WorkFlow_Node { get; set; }

        /// <summary>
        /// 审批人ID
        /// </summary>
        [Display(Name = "员工表ID")]
        public int GroupAccountID { get; set; }
        public virtual GroupAccount GroupAccount { get; set; }



        /// <summary>
        /// 职位主表ID
        /// </summary>
        [Display(Name = "职位主表ID")]
        public int PositionID { get; set; }
        public virtual Position Position { get; set; }
    }
}
