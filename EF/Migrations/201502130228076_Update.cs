namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Financing", new[] { "WorkFlowManagerID" });
            AlterColumn("dbo.Financing", "WorkFlowManagerID", c => c.Int());
            CreateIndex("dbo.Financing", "WorkFlowManagerID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Financing", new[] { "WorkFlowManagerID" });
            AlterColumn("dbo.Financing", "WorkFlowManagerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Financing", "WorkFlowManagerID");
        }
    }
}
