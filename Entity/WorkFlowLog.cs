using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 项目日志
    /// </summary>
    public class WorkFlowLog : BaseEntity
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
        /// 节点名称
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 工作内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 提交日期
        /// </summary>
        public DateTime Date { get; set; }
    }
}
