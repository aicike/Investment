using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class WorkLog : BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        [Display(Name = "内容")]
        [Required(ErrorMessage = "内容不能为空")]
        public string Log { get; set; }

        [Display(Name = "记录时间")]
        public DateTime LogDate { get; set; }

        public int GroupAccountID { get; set; }

        public virtual GroupAccount GroupAccount { get; set; }

        public int? WorkFlowID { get; set; }

        public virtual WorkFlow WorkFlow { get; set; }

        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 天
        /// </summary>
        public int day { get; set; }
    }
}
