using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace EF.Mapping
{
    public class RoleOptionMap : EntityTypeConfiguration<RoleOption>
    {
        public RoleOptionMap()
        {
            this.HasRequired(a => a.Role)
            .WithMany(a => a.RoleOptions)
            .HasForeignKey(a => a.RoleID).WillCascadeOnDelete(true);
        }
    }
}
