using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 流程对应产品信息表
    /// </summary>
    public class WorkFlowMechanismProduct : BaseEntity
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
        /// 机构产品表ID
        /// </summary>
        [Display(Name = "机构产品表ID")]
        public int MechanismProductsID { get; set; }
        public virtual MechanismProducts MechanismProducts { get; set; }

        /// <summary>
        /// 机构数据 JSON
        /// </summary>
        [Display(Name = "机构数据 JSON")]
        public string FormJson { get; set; }


    }
}
