using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 行业规模，级别
    /// </summary>
    public class IndustryLevel:BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 0微型，1小型，2中型，3大型
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// （最大）营业收入
        /// </summary>
        public double? YingYeShouRu { get; set; }

        /// <summary>
        /// （最大）总资产
        /// </summary>
        public double? ZongZiChan { get; set; }

        /// <summary>
        /// 最大从业人员
        /// </summary>
        public int? ChongYeRenYuan { get; set; }

        /// <summary>
        /// 行业
        /// </summary>
        public int IndustryID { get; set; }

        public virtual Industry Industry { get; set; }

        public virtual ICollection<Company> Companys { get; set; }
    }
}
