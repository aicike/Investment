using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    /// <summary>
    /// 机构产品表
    /// </summary>
    public class MechanismProducts : BaseEntity
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Required(ErrorMessage = "请输入产品名称")]
        public string Name { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string MechanismName { get; set; }

        /// <summary>
        /// 最高贷款额度（万）
        /// </summary>
        [Required(ErrorMessage = "请输入最高贷款额度")]
        public double MaxQuota { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否启用 true正常 false禁用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 机构表ID
        /// </summary>
        [Display(Name = "机构表ID")]
        public int? MechanismID { get; set; }
        public virtual Mechanism Mechanism { get; set; }


        
        //-------------子表----------------------------
        /// <summary>
        /// 流程对应产品信息表
        /// </summary>
        public virtual ICollection<WorkFlowMechanismProduct> WorkFlowMechanismProduct { get; set; }

        //不在数据库中生成
        /// <summary>
        /// 状态 0待定中，1进行中，2结束，3放款机构
        /// </summary>
        public int State { get; set; }
    }
}
