namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update34 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovalRecord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkFlowID = c.Int(nullable: false),
                        GroupAccountID = c.Int(nullable: false),
                        NodeName = c.String(),
                        AccountName = c.String(),
                        AccountPosition = c.String(),
                        Opinion = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GroupAccount", t => t.GroupAccountID)
                .ForeignKey("dbo.WorkFlow", t => t.WorkFlowID)
                .Index(t => t.WorkFlowID)
                .Index(t => t.GroupAccountID);
            
            CreateTable(
                "dbo.WorkFlow",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        WorkFlowManagerID = c.Int(nullable: false),
                        FinancingID = c.Int(nullable: false),
                        GroupAccountID = c.Int(nullable: false),
                        FormJson = c.String(),
                        State = c.Int(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        WorkFlow_NodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Financing", t => t.FinancingID)
                .ForeignKey("dbo.WorkFlowManager", t => t.WorkFlowManagerID)
                .ForeignKey("dbo.WorkFlow_Node", t => t.WorkFlow_NodeID)
                .ForeignKey("dbo.GroupAccount", t => t.GroupAccountID)
                .Index(t => t.WorkFlowManagerID)
                .Index(t => t.FinancingID)
                .Index(t => t.GroupAccountID)
                .Index(t => t.WorkFlow_NodeID);
            
            CreateTable(
                "dbo.WorkFlowMechanismProduct",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkFlowID = c.Int(nullable: false),
                        MechanismProductsID = c.Int(nullable: false),
                        FormJson = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MechanismProducts", t => t.MechanismProductsID)
                .ForeignKey("dbo.WorkFlow", t => t.WorkFlowID)
                .Index(t => t.WorkFlowID)
                .Index(t => t.MechanismProductsID);
            
            CreateTable(
                "dbo.MechanismProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MechanismName = c.String(),
                        MaxQuota = c.Double(nullable: false),
                        Remark = c.String(),
                        IsEnable = c.Boolean(nullable: false),
                        MechanismID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Mechanism", t => t.MechanismID)
                .Index(t => t.MechanismID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkFlowMechanismProduct", "WorkFlowID", "dbo.WorkFlow");
            DropForeignKey("dbo.WorkFlowMechanismProduct", "MechanismProductsID", "dbo.MechanismProducts");
            DropForeignKey("dbo.MechanismProducts", "MechanismID", "dbo.Mechanism");
            DropForeignKey("dbo.WorkFlow", "GroupAccountID", "dbo.GroupAccount");
            DropForeignKey("dbo.WorkFlow", "WorkFlow_NodeID", "dbo.WorkFlow_Node");
            DropForeignKey("dbo.WorkFlow", "WorkFlowManagerID", "dbo.WorkFlowManager");
            DropForeignKey("dbo.WorkFlow", "FinancingID", "dbo.Financing");
            DropForeignKey("dbo.ApprovalRecord", "WorkFlowID", "dbo.WorkFlow");
            DropForeignKey("dbo.ApprovalRecord", "GroupAccountID", "dbo.GroupAccount");
            DropIndex("dbo.MechanismProducts", new[] { "MechanismID" });
            DropIndex("dbo.WorkFlowMechanismProduct", new[] { "MechanismProductsID" });
            DropIndex("dbo.WorkFlowMechanismProduct", new[] { "WorkFlowID" });
            DropIndex("dbo.WorkFlow", new[] { "WorkFlow_NodeID" });
            DropIndex("dbo.WorkFlow", new[] { "GroupAccountID" });
            DropIndex("dbo.WorkFlow", new[] { "FinancingID" });
            DropIndex("dbo.WorkFlow", new[] { "WorkFlowManagerID" });
            DropIndex("dbo.ApprovalRecord", new[] { "GroupAccountID" });
            DropIndex("dbo.ApprovalRecord", new[] { "WorkFlowID" });
            DropTable("dbo.MechanismProducts");
            DropTable("dbo.WorkFlowMechanismProduct");
            DropTable("dbo.WorkFlow");
            DropTable("dbo.ApprovalRecord");
        }
    }
}
