using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace EF.Mapping
{
    public class RoleAccountMap : EntityTypeConfiguration<RoleAccount>
    {
        public RoleAccountMap()
        {
            this.HasRequired(a => a.Role)
            .WithMany(a => a.RoleAccounts)
            .HasForeignKey(a => a.RoleID).WillCascadeOnDelete(true);
        }
    }
}
