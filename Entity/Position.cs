using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 职位管理表
    /// </summary>
    public class Position:BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 职位名称
        /// </summary>
        [Required(ErrorMessage = "请输入职位名称")]
        [StringLength(50, ErrorMessage = "职位名称不能超过50字")]
        public string Name { get; set; }

        //-------------子表----------------------------
        /// <summary>
        /// 职位与员工中间表
        /// </summary>
        public virtual ICollection<Position_Account> Position_Account { get; set; }

        /// <summary>
        /// 审批人表
        /// </summary>
        public virtual ICollection<WorkFlowApprovalManager> WorkFlowApprovalManager { get; set; }

    }
}
