using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace EF.Mapping
{
    public class WorkFlowMap : EntityTypeConfiguration<WorkFlow>
    {
        public WorkFlowMap()
        {
            this.HasOptional(a => a.JSON_Owner_A)
            .WithMany(a => a.WorkFlow_A)
            .HasForeignKey(a => a.JSON_Owner_A_ID);

            this.HasOptional(a => a.JSON_Owner_B)
            .WithMany(a => a.WorkFlow_B)
            .HasForeignKey(a => a.JSON_Owner_B_ID);
        }
    }
}
