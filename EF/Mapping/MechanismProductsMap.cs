using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Entity;

namespace EF.Mapping
{
    public class MechanismProductsMap : EntityTypeConfiguration<MechanismProducts>
    {
        public MechanismProductsMap() {
            this.Ignore(a=>a.State);
        }
    }
}
