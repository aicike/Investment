using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 职位与用户中间表
    /// </summary>
    public class Position_Account:BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// 职位主表ID
        /// </summary>
        [Display(Name = "职位主表ID")]
        public int PositionID { get; set; }
        public virtual Position Position { get; set; }


        /// <summary>
        /// 员工表ID
        /// </summary>
        [Display(Name = "员工表ID")]
        public int GroupAccountID { get; set; }
        public virtual GroupAccount GroupAccount { get; set; }
    }
}
