using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CompanyRelation:BaseEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 被关联公司的ID
        /// </summary>
        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }

        /// <summary>
        /// 主关联公司的ID
        /// </summary>
        public int RelationObjectID { get; set; }

        public virtual Company RelationObject { get; set; }
    }
}
