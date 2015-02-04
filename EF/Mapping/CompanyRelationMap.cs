using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.Entity.ModelConfiguration;

namespace EF.Mapping
{
    public class CompanyRelationMap : EntityTypeConfiguration<CompanyRelation>
    {
        public CompanyRelationMap()
        {
            this.HasRequired(a => a.Company)
            .WithMany(a => a.CompanyRelations1)
            .HasForeignKey(a => a.CompanyID);

            this.HasRequired(a => a.RelationObject)
            .WithMany(a => a.CompanyRelations2)
            .HasForeignKey(a => a.RelationObjectID);
        }
    }
}
