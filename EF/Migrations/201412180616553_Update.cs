namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                        SetUpTime = c.DateTime(nullable: false),
                        ChengLiShiJianJiYingYeQiXian = c.String(),
                        ZhuCheZiJin = c.Double(nullable: false),
                        ShiShouZiBen = c.Double(nullable: false),
                        FaDingDaiBiaoRen = c.String(),
                        ZiChanZongE = c.Double(nullable: false),
                        FuZhaiZongE = c.Double(nullable: false),
                        ZhuYingYeWuShouRu = c.Double(nullable: false),
                        JingLiRun = c.Double(nullable: false),
                        HuoYouFuZhai = c.Double(nullable: false),
                        KeWoGongQiuGuanXi = c.String(),
                        NiDaiKuanYinHang = c.String(),
                        GuQuanJieGou = c.String(),
                        ShiJiKongZhiRenXinYongJiLu = c.String(),
                        XinYongDengJi = c.String(),
                        JingYingQingKuangJiQiBianDong = c.String(),
                        HeXinJingZhengLi = c.String(),
                        CaiWuQingKuangJiQiBianDong = c.String(),
                        CaiWuQingKuang = c.String(),
                        GuanLianFangJiGuanLianFangJiaoYi = c.String(),
                        MuQianDaiKuanDanBaoZhiXingQingKuang = c.String(),
                        DiZhiYaFanDanBao = c.String(),
                        QiYeXingZhi = c.String(),
                        YingYeZhiZhao = c.String(),
                        JingYingFanWei = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.GroupID)
                .Index(t => t.GroupID);
            
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


            var migrationDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\");
            var ddlSqlFiles = new string[] { "Initial.sql" };
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
            DropForeignKey("dbo.RoleAccount", "CompanyAccountID", "dbo.CompanyAccount");
            DropForeignKey("dbo.CompanyAccount", "CompanyID", "dbo.Company");
            DropIndex("dbo.CompanyLoan", new[] { "CompanyID" });
            DropIndex("dbo.RoleOption", new[] { "MenuOptionID" });
            DropIndex("dbo.RoleOption", new[] { "RoleID" });
            DropIndex("dbo.MenuOption", new[] { "MenuID" });
            DropIndex("dbo.Menu", new[] { "ParentMenuID" });
            DropIndex("dbo.RoleMenu", new[] { "RoleID" });
            DropIndex("dbo.RoleMenu", new[] { "MenuID" });
            DropIndex("dbo.GroupAccount", new[] { "GroupID" });
            DropIndex("dbo.RoleAccount", new[] { "CompanyAccountID" });
            DropIndex("dbo.RoleAccount", new[] { "GroupAccountID" });
            DropIndex("dbo.RoleAccount", new[] { "RoleID" });
            DropIndex("dbo.CompanyAccount", new[] { "CompanyID" });
            DropTable("dbo.CompanyLoan");
            DropTable("dbo.RoleOption");
            DropTable("dbo.MenuOption");
            DropTable("dbo.Menu");
            DropTable("dbo.RoleMenu");
            DropTable("dbo.Role");
            DropTable("dbo.Group");
            DropTable("dbo.GroupAccount");
            DropTable("dbo.RoleAccount");
            DropTable("dbo.CompanyAccount");
            DropTable("dbo.Company");
        }
    }
}
