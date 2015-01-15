namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Log = c.String(nullable: false),
                        LogDate = c.DateTime(nullable: false),
                        GroupAccountID = c.Int(nullable: false),
                        WorkFlowID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GroupAccount", t => t.GroupAccountID)
                .ForeignKey("dbo.WorkFlow", t => t.WorkFlowID)
                .Index(t => t.GroupAccountID)
                .Index(t => t.WorkFlowID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkLog", "WorkFlowID", "dbo.WorkFlow");
            DropForeignKey("dbo.WorkLog", "GroupAccountID", "dbo.GroupAccount");
            DropIndex("dbo.WorkLog", new[] { "WorkFlowID" });
            DropIndex("dbo.WorkLog", new[] { "GroupAccountID" });
            DropTable("dbo.WorkLog");
        }
    }
}
