﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CompanyRelation:BaseEntity
    {
        public int ID { get; set; }

        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }

        public int RelationID { get; set; }

        public virtual Relation Relation { get; set; }
    }
}
