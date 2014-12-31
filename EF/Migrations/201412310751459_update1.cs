namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "ZhuYingYeWu", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "ZhuYingYeWu");
        }
    }
}
