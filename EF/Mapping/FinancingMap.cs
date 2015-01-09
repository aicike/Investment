using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace EF.Mapping
{
    public class FinancingMap : EntityTypeConfiguration<Financing>
    {
        public FinancingMap()
        {
            this.HasOptional(a => a.Owner_A)
            .WithMany(a => a.Financings_A)
            .HasForeignKey(a => a.Owner_A_ID);

            this.HasOptional(a => a.Owner_B)
            .WithMany(a => a.Financings_B)
            .HasForeignKey(a => a.Owner_B_ID);
        }
    }
}
