using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 意向匹配数据
    /// </summary>
    public class FinancingMatching:BaseEntity
    {
        /// <summary>
        /// 意向ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 意向ID
        /// </summary>
        public int FID { get; set; }

        /// <summary>
        /// 意向名称
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 机构产品ID
        /// </summary>
        public int MID { get; set; }

        /// <summary>
        /// 机构产品名称
        /// </summary>
        public string MName { get; set; }
             
    }
}
