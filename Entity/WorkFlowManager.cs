using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 流程分类管理表
    /// </summary>
    public class WorkFlowManager:BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        [Display(Name = "流程名称")]
        [Required(ErrorMessage = "请输入流程名称")]
        public string Name { get; set; }

        /// <summary>
        /// 是否启用 true启用 false禁用
        /// </summary>
        [Display(Name = "是否启用")]
        public bool IsEnable { get; set; }


        //-------------子表----------------------------
        /// <summary>
        /// 流程与节点中间表
        /// </summary>
        public virtual ICollection<WorkFlow_Node> WorkFlow_Node { get; set; }

        /// <summary>
        /// 流程表
        /// </summary>
        public virtual ICollection<WorkFlow> WorkFlow { get; set; }
    }
}
