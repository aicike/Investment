using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace EF.Mapping
{
    public class RoleMenuMap : EntityTypeConfiguration<RoleMenu>
    {
        public RoleMenuMap()
        {
            this.HasRequired(a => a.Role)
            .WithMany(a => a.RoleMenus)
            .HasForeignKey(a => a.RoleID).WillCascadeOnDelete(true);
        }
    }
}
