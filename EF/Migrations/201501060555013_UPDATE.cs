namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Financing", "FinancingCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Financing", "FinancingCost", c => c.String(nullable: false));
        }
    }
}
