using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class WorkFlow_Node: BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 流程表ID
        /// </summary>
        [Display(Name = "流程表ID")]
        public int WorkFlowManagerID { get; set; }
        public virtual WorkFlowManager WorkFlowManager { get; set; }

        /// <summary>
        /// 流程节点表ID
        /// </summary>
        [Display(Name = "流程节点表ID")]
        public int WorkFlowNodeManagerID { get; set; }
        public virtual WorkFlowNodeManager WorkFlowNodeManager { get; set; }

        /// <summary>
        /// 执行顺序 升序
        /// </summary>
        public int Order { get; set; }

        //-------------子表----------------------------
        /// <summary>
        /// 审批人表
        /// </summary>
        public virtual ICollection<WorkFlowApprovalManager> WorkFlowApprovalManager { get; set; }

        /// <summary>
        /// 流程表
        /// </summary>
        public virtual ICollection<WorkFlow> WorkFlow { get; set; }

    }
}
