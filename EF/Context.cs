using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entity;
using EF.Mapping;

namespace EF
{
    public class Context : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyAccount> CompanyAccount { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupAccount> GroupAccount { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<Mechanism> Mechanism { get; set; }
        public DbSet<WorkFlowManager> WorkFlowManager { get; set; }
        public DbSet<Financing> Financings { get; set; }
        public DbSet<MechanismProducts> MechanismProducts { get; set; }
        

        

        //数据库生成的其他设置
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new RoleAccountMap());
            modelBuilder.Configurations.Add(new RoleMenuMap());
            modelBuilder.Configurations.Add(new RoleOptionMap());
            modelBuilder.Configurations.Add(new FinancingMap());
        }
    }
}
