namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName_Number = c.String(),
                        FileName = c.String(),
                        FilePath = c.String(),
                        FileUrl = c.String(),
                        TableName = c.String(),
                        TableID = c.Int(nullable: false),
                        EnumAttachmentType = c.Int(nullable: false),
                        EnumAttachmentFormat = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        OwnerID = c.Int(),
                        IsComplete = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 200),
                        SetUpTime = c.DateTime(nullable: false),
                        ChengLiShiJianJiYingYeQiXian = c.String(),
                        ZhuCheZiJin = c.Double(nullable: false),
                        ShiShouZiBen = c.Double(nullable: false),
                        FaDingDaiBiaoRen = c.String(nullable: false),
                        ZiChanZongE = c.Double(nullable: false),
                        FuZhaiZongE = c.Double(nullable: false),
                        ZhuYingYeWuShouRu = c.Double(nullable: false),
                        ChengBen = c.Double(nullable: false),
                        ZhuYingYeWu = c.String(nullable: false),
                        JingLiRun = c.Double(nullable: false),
                        HuoYouFuZhai = c.Double(nullable: false),
                        KeWoGongQiuGuanXi = c.String(),
                        NiDaiKuanYinHang = c.String(),
                        GuQuanJieGou = c.String(),
                        ShiJiKongZhiRen = c.String(nullable: false),
                        ShiJiKongZhiRenXinYongJiLu = c.String(),
                        XinYongDengJi = c.String(),
                        JingYingQingKuangJiQiBianDong = c.String(),
                        HeXinJingZhengLi = c.String(),
                        CaiWuQingKuangJiQiBianDong = c.String(),
                        CaiWuQingKuang = c.String(),
                        GuanLianFangJiGuanLianFangJiaoYi = c.String(),
                        MuQianDaiKuanDanBaoZhiXingQingKuang = c.String(),
                        DiZhiYaFanDanBao = c.String(),
                        QiYeXingZhi = c.String(nullable: false),
                        YingYeZhiZhao = c.String(),
                        JingYingFanWei = c.String(),
                        DaiKuanKa = c.String(),
                        QiYeZiZhi = c.String(nullable: false),
                        GuanLianGongSi = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GroupAccount", t => t.OwnerID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.CompanyAccount",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        AccountNumber = c.String(nullable: false, maxLength: 50),
                        AccountPwd = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        HeadPortrait = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.RoleAccount",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        GroupAccountID = c.Int(),
                        CompanyAccountID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CompanyAccount", t => t.CompanyAccountID)
                .ForeignKey("dbo.GroupAccount", t => t.GroupAccountID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.GroupAccountID)
                .Index(t => t.CompanyAccountID);
            
            CreateTable(
                "dbo.GroupAccount",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        AccountNumber = c.String(nullable: false, maxLength: 50),
                        AccountPwd = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        HeadPortrait = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.GroupID)
                .Index(t => t.GroupID);
            
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
                        Operation = c.Int(nullable: false),
                        Date = c.DateTime(),
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
                        FinancingID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        FormJson = c.String(),
                        State = c.Int(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        WorkFlow_NodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.Financing", t => t.FinancingID)
                .ForeignKey("dbo.WorkFlow_Node", t => t.WorkFlow_NodeID)
                .Index(t => t.FinancingID)
                .Index(t => t.CompanyID)
                .Index(t => t.WorkFlow_NodeID);
            
            CreateTable(
                "dbo.Financing",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        Owner_A_ID = c.Int(),
                        Owner_B_ID = c.Int(),
                        Status = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Amount = c.Double(nullable: false),
                        MinTimeLimit = c.Int(nullable: false),
                        MaxTimeLimit = c.Int(nullable: false),
                        ShouYiLvType = c.Int(nullable: false),
                        ShouYiLv = c.Double(nullable: false),
                        FinancingCost = c.Double(nullable: false),
                        Purpose = c.String(nullable: false),
                        Repayment = c.String(nullable: false),
                        RongZiBiaoDi = c.String(),
                        ZengXinCuoShi = c.String(nullable: false),
                        RongZiFangAn = c.String(nullable: false),
                        Remark = c.String(),
                        BusinessResource = c.String(nullable: false),
                        WorkFlowManagerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.GroupAccount", t => t.Owner_A_ID)
                .ForeignKey("dbo.GroupAccount", t => t.Owner_B_ID)
                .ForeignKey("dbo.WorkFlowManager", t => t.WorkFlowManagerID)
                .Index(t => t.CompanyID)
                .Index(t => t.Owner_A_ID)
                .Index(t => t.Owner_B_ID)
                .Index(t => t.WorkFlowManagerID);
            
            CreateTable(
                "dbo.WorkFlowManager",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsEnable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkFlow_Node",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkFlowManagerID = c.Int(nullable: false),
                        WorkFlowNodeManagerID = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WorkFlowManager", t => t.WorkFlowManagerID)
                .ForeignKey("dbo.WorkFlowNodeManager", t => t.WorkFlowNodeManagerID)
                .Index(t => t.WorkFlowManagerID)
                .Index(t => t.WorkFlowNodeManagerID);
            
            CreateTable(
                "dbo.WorkFlowApprovalManager",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WorkFlow_NodeID = c.Int(nullable: false),
                        GroupAccountID = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GroupAccount", t => t.GroupAccountID)
                .ForeignKey("dbo.Position", t => t.PositionID)
                .ForeignKey("dbo.WorkFlow_Node", t => t.WorkFlow_NodeID)
                .Index(t => t.WorkFlow_NodeID)
                .Index(t => t.GroupAccountID)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Position_Account",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PositionID = c.Int(nullable: false),
                        GroupAccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GroupAccount", t => t.GroupAccountID)
                .ForeignKey("dbo.Position", t => t.PositionID)
                .Index(t => t.PositionID)
                .Index(t => t.GroupAccountID);
            
            CreateTable(
                "dbo.WorkFlowNodeManager",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Remark = c.String(),
                        IsSinceApproval = c.Boolean(nullable: false),
                        Controllers = c.String(),
                        Acction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateTable(
                "dbo.Mechanism",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountType = c.Int(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleMenu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menu", t => t.MenuID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.MenuID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Area = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                        AccountType = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        ShowName = c.String(nullable: false, maxLength: 20),
                        Order = c.Int(nullable: false),
                        IsShow = c.Boolean(),
                        ParentMenuID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menu", t => t.ParentMenuID)
                .Index(t => t.ParentMenuID);
            
            CreateTable(
                "dbo.MenuOption",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MenuID = c.Int(nullable: false),
                        Name = c.String(),
                        Controller = c.String(),
                        Action = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Menu", t => t.MenuID)
                .Index(t => t.MenuID);
            
            CreateTable(
                "dbo.RoleOption",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        MenuOptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuOption", t => t.MenuOptionID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.MenuOptionID);
            
            CreateTable(
                "dbo.CompanyLoan",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        XiangMuMingCheng = c.String(),
                        XiangMuLeiXing = c.String(),
                        RongZiJinE = c.Double(nullable: false),
                        RongZiQiXian = c.Double(nullable: false),
                        RongZiChengBen = c.Double(nullable: false),
                        RongZiYongTu = c.String(),
                        HuanKuanLaiYuan = c.String(),
                        RongZiBiaoDi = c.String(),
                        ZengXinCuoShi = c.String(),
                        RongZiFangAn = c.String(),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.CompanyRelation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        RelationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.Relation", t => t.RelationID)
                .Index(t => t.CompanyID)
                .Index(t => t.RelationID);
            
            CreateTable(
                "dbo.Relation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);

            var migrationDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\");
            var ddlSqlFiles = new string[] {  "Initial.sql" };
            foreach (var file in ddlSqlFiles)
            {
                string scriptText = System.IO.File.ReadAllText(System.IO.Path.Combine(migrationDir, file));
                var commandTexts = scriptText.Split(new string[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var commandText in commandTexts)
                {
                    if (!String.IsNullOrWhiteSpace(commandText))
                        Sql(commandText);
                }
            }
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyRelation", "RelationID", "dbo.Relation");
            DropForeignKey("dbo.CompanyRelation", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.CompanyLoan", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.RoleAccount", "RoleID", "dbo.Role");
            DropForeignKey("dbo.RoleMenu", "RoleID", "dbo.Role");
            DropForeignKey("dbo.RoleMenu", "MenuID", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentMenuID", "dbo.Menu");
            DropForeignKey("dbo.RoleOption", "RoleID", "dbo.Role");
            DropForeignKey("dbo.RoleOption", "MenuOptionID", "dbo.MenuOption");
            DropForeignKey("dbo.MenuOption", "MenuID", "dbo.Menu");
            DropForeignKey("dbo.RoleAccount", "GroupAccountID", "dbo.GroupAccount");
            DropForeignKey("dbo.GroupAccount", "GroupID", "dbo.Group");
            DropForeignKey("dbo.Company", "OwnerID", "dbo.GroupAccount");
            DropForeignKey("dbo.WorkFlowMechanismProduct", "WorkFlowID", "dbo.WorkFlow");
            DropForeignKey("dbo.WorkFlowMechanismProduct", "MechanismProductsID", "dbo.MechanismProducts");
            DropForeignKey("dbo.MechanismProducts", "MechanismID", "dbo.Mechanism");
            DropForeignKey("dbo.WorkFlow_Node", "WorkFlowNodeManagerID", "dbo.WorkFlowNodeManager");
            DropForeignKey("dbo.WorkFlow_Node", "WorkFlowManagerID", "dbo.WorkFlowManager");
            DropForeignKey("dbo.WorkFlowApprovalManager", "WorkFlow_NodeID", "dbo.WorkFlow_Node");
            DropForeignKey("dbo.WorkFlowApprovalManager", "PositionID", "dbo.Position");
            DropForeignKey("dbo.Position_Account", "PositionID", "dbo.Position");
            DropForeignKey("dbo.Position_Account", "GroupAccountID", "dbo.GroupAccount");
            DropForeignKey("dbo.WorkFlowApprovalManager", "GroupAccountID", "dbo.GroupAccount");
            DropForeignKey("dbo.WorkFlow", "WorkFlow_NodeID", "dbo.WorkFlow_Node");
            DropForeignKey("dbo.Financing", "WorkFlowManagerID", "dbo.WorkFlowManager");
            DropForeignKey("dbo.WorkFlow", "FinancingID", "dbo.Financing");
            DropForeignKey("dbo.Financing", "Owner_B_ID", "dbo.GroupAccount");
            DropForeignKey("dbo.Financing", "Owner_A_ID", "dbo.GroupAccount");
            DropForeignKey("dbo.Financing", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.WorkFlow", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.ApprovalRecord", "WorkFlowID", "dbo.WorkFlow");
            DropForeignKey("dbo.ApprovalRecord", "GroupAccountID", "dbo.GroupAccount");
            DropForeignKey("dbo.RoleAccount", "CompanyAccountID", "dbo.CompanyAccount");
            DropForeignKey("dbo.CompanyAccount", "CompanyID", "dbo.Company");
            DropIndex("dbo.CompanyRelation", new[] { "RelationID" });
            DropIndex("dbo.CompanyRelation", new[] { "CompanyID" });
            DropIndex("dbo.CompanyLoan", new[] { "CompanyID" });
            DropIndex("dbo.RoleOption", new[] { "MenuOptionID" });
            DropIndex("dbo.RoleOption", new[] { "RoleID" });
            DropIndex("dbo.MenuOption", new[] { "MenuID" });
            DropIndex("dbo.Menu", new[] { "ParentMenuID" });
            DropIndex("dbo.RoleMenu", new[] { "RoleID" });
            DropIndex("dbo.RoleMenu", new[] { "MenuID" });
            DropIndex("dbo.MechanismProducts", new[] { "MechanismID" });
            DropIndex("dbo.WorkFlowMechanismProduct", new[] { "MechanismProductsID" });
            DropIndex("dbo.WorkFlowMechanismProduct", new[] { "WorkFlowID" });
            DropIndex("dbo.Position_Account", new[] { "GroupAccountID" });
            DropIndex("dbo.Position_Account", new[] { "PositionID" });
            DropIndex("dbo.WorkFlowApprovalManager", new[] { "PositionID" });
            DropIndex("dbo.WorkFlowApprovalManager", new[] { "GroupAccountID" });
            DropIndex("dbo.WorkFlowApprovalManager", new[] { "WorkFlow_NodeID" });
            DropIndex("dbo.WorkFlow_Node", new[] { "WorkFlowNodeManagerID" });
            DropIndex("dbo.WorkFlow_Node", new[] { "WorkFlowManagerID" });
            DropIndex("dbo.Financing", new[] { "WorkFlowManagerID" });
            DropIndex("dbo.Financing", new[] { "Owner_B_ID" });
            DropIndex("dbo.Financing", new[] { "Owner_A_ID" });
            DropIndex("dbo.Financing", new[] { "CompanyID" });
            DropIndex("dbo.WorkFlow", new[] { "WorkFlow_NodeID" });
            DropIndex("dbo.WorkFlow", new[] { "CompanyID" });
            DropIndex("dbo.WorkFlow", new[] { "FinancingID" });
            DropIndex("dbo.ApprovalRecord", new[] { "GroupAccountID" });
            DropIndex("dbo.ApprovalRecord", new[] { "WorkFlowID" });
            DropIndex("dbo.GroupAccount", new[] { "GroupID" });
            DropIndex("dbo.RoleAccount", new[] { "CompanyAccountID" });
            DropIndex("dbo.RoleAccount", new[] { "GroupAccountID" });
            DropIndex("dbo.RoleAccount", new[] { "RoleID" });
            DropIndex("dbo.CompanyAccount", new[] { "CompanyID" });
            DropIndex("dbo.Company", new[] { "OwnerID" });
            DropTable("dbo.Relation");
            DropTable("dbo.CompanyRelation");
            DropTable("dbo.CompanyLoan");
            DropTable("dbo.RoleOption");
            DropTable("dbo.MenuOption");
            DropTable("dbo.Menu");
            DropTable("dbo.RoleMenu");
            DropTable("dbo.Role");
            DropTable("dbo.Group");
            DropTable("dbo.Mechanism");
            DropTable("dbo.MechanismProducts");
            DropTable("dbo.WorkFlowMechanismProduct");
            DropTable("dbo.WorkFlowNodeManager");
            DropTable("dbo.Position_Account");
            DropTable("dbo.Position");
            DropTable("dbo.WorkFlowApprovalManager");
            DropTable("dbo.WorkFlow_Node");
            DropTable("dbo.WorkFlowManager");
            DropTable("dbo.Financing");
            DropTable("dbo.WorkFlow");
            DropTable("dbo.ApprovalRecord");
            DropTable("dbo.GroupAccount");
            DropTable("dbo.RoleAccount");
            DropTable("dbo.CompanyAccount");
            DropTable("dbo.Company");
            DropTable("dbo.Attachment");
        }
    }
}
