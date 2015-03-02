using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 行业
    /// </summary>
    public class Industry:BaseEntity
    {

        public int ID { get; set; }

        /// <summary>
        /// 行业名称
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<IndustryLevel> IndustryLevels { get; set; }

        public virtual ICollection<Company> Companys { get; set; }
    }
}
