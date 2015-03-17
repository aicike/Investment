using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 利息表
    /// </summary>
    public class Interest : BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 流程表ID
        /// </summary>
        [Display(Name = "流程表ID")]
        public int WorkFlowID { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 是否收费 ture是
        /// </summary>
        public bool IsCharge { get; set; }

        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime? OperDate { get; set; }

        /// <summary>
        /// 类别 0 最小还款月份 1最多还款月份
        /// </summary>
        public int? type { get; set; }

        /// <summary>
        /// 是否已经给项目经理发送通知
        /// </summary>
        public bool JLSendEmail { get; set; }

        /// <summary>
        /// 是否已给财务总监发送通知
        /// </summary>
        public bool CWZJSendEmail { get; set; }
    }
}
