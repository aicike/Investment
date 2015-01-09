namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "ZhuYingYeWu", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "ZhuYingYeWu", c => c.Double(nullable: false));
        }
    }
}
