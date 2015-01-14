using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 流程节点管理
    /// </summary>
    public class WorkFlowNodeManager:BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// 流程节点名称
        /// </summary>
        [Display(Name = "流程节点名称")]
        [Required(ErrorMessage = "请输入流程名称")]
        public string Name { get; set; }

        /// <summary>
        /// 流程节点备注
        /// </summary>
        [Display(Name = "流程节点备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 是否自审批 true是 false否（提交表单的人）
        /// </summary>
        public bool IsSinceApproval { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public string Controllers { get; set; }

        /// <summary>
        /// 视图方法
        /// </summary>
        public string Action { get; set; }


        //-------------子表----------------------------
        /// <summary>
        /// 流程与节点中间表
        /// </summary>
        public virtual ICollection<WorkFlow_Node> WorkFlow_Node { get; set; }
    }
}
