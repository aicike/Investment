namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyHistory", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.FinancingHistory", "FinancingID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FinancingHistory", "FinancingID");
            DropColumn("dbo.CompanyHistory", "CompanyID");
        }
    }
}
