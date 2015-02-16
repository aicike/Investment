namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adds : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Financing", new[] { "WorkFlowManagerID" });
            AddColumn("dbo.WorkFlow", "JSON_Owner_A_ID", c => c.Int());
            AddColumn("dbo.WorkFlow", "JSON_Owner_B_ID", c => c.Int());
            AddColumn("dbo.Financing", "AuditStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Financing", "WorkFlowManagerID", c => c.Int());
            CreateIndex("dbo.WorkFlow", "JSON_Owner_A_ID");
            CreateIndex("dbo.WorkFlow", "JSON_Owner_B_ID");
            CreateIndex("dbo.Financing", "WorkFlowManagerID");
            AddForeignKey("dbo.WorkFlow", "JSON_Owner_A_ID", "dbo.GroupAccount", "ID");
            AddForeignKey("dbo.WorkFlow", "JSON_Owner_B_ID", "dbo.GroupAccount", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkFlow", "JSON_Owner_B_ID", "dbo.GroupAccount");
            DropForeignKey("dbo.WorkFlow", "JSON_Owner_A_ID", "dbo.GroupAccount");
            DropIndex("dbo.Financing", new[] { "WorkFlowManagerID" });
            DropIndex("dbo.WorkFlow", new[] { "JSON_Owner_B_ID" });
            DropIndex("dbo.WorkFlow", new[] { "JSON_Owner_A_ID" });
            AlterColumn("dbo.Financing", "WorkFlowManagerID", c => c.Int(nullable: false));
            DropColumn("dbo.Financing", "AuditStatus");
            DropColumn("dbo.WorkFlow", "JSON_Owner_B_ID");
            DropColumn("dbo.WorkFlow", "JSON_Owner_A_ID");
            CreateIndex("dbo.Financing", "WorkFlowManagerID");
        }
    }
}
