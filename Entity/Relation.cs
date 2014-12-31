using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Relation:BaseEntity
    {
        public int ID { get; set; }

        public virtual ICollection<CompanyRelation> CompanyRelations { get; set; }
    }
}
