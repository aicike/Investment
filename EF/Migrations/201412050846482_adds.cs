namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BudgetClass",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CoefficientURL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.GroupID)
                .Index(t => t.GroupID);
            
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
                .ForeignKey("dbo.Role", t => t.RoleID)
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
                .ForeignKey("dbo.Role", t => t.RoleID)
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
                .ForeignKey("dbo.Role", t => t.RoleID)
                .Index(t => t.RoleID)
                .Index(t => t.MenuOptionID);
            
            CreateTable(
                "dbo.ProfitLoss_Coefficient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        FenQiShuLiang = c.Double(nullable: false),
                        XinBaoShuLiang = c.Double(nullable: false),
                        XuBaoShuLiang = c.Double(nullable: false),
                        GuaPaiShuLiang = c.Double(nullable: false),
                        ErShouCheXiaoShouShuLiang = c.Double(nullable: false),
                        ZhuYingShouRu_ZhengChe = c.Double(nullable: false),
                        ZhuYingShouRu_ZhuangShiZhuangHuang = c.Double(nullable: false),
                        ZhuYingShouRu_FenQi = c.Double(nullable: false),
                        ZhuYingShouRu_XinBao = c.Double(nullable: false),
                        ZhuYingShouRu_XuBao = c.Double(nullable: false),
                        ZhuYingShouRu_GuaPai = c.Double(nullable: false),
                        ZhuYingShouRu_ErShouChe = c.Double(nullable: false),
                        ZhuYingChengBen_ZhengChe = c.Double(nullable: false),
                        ZhuYingChengBen_WeiXiuPeiJian = c.Double(nullable: false),
                        ZhuYingChengBen_ZhuangShiZhuangHuang = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.ProfitLoss_Detailed",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        ProfitLoss_MainID = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        XiaoShouShuLiang = c.Double(nullable: false),
                        XinCheXiaoShouShuLiang = c.Double(nullable: false),
                        WeiXiuJinChangTaiCi = c.Double(nullable: false),
                        FenQiShuLiang = c.Double(nullable: false),
                        XinBaoShuLiang = c.Double(nullable: false),
                        XuBaoShuLiang = c.Double(nullable: false),
                        YanBaoShuLiang = c.Double(),
                        GuaPaiShuLiang = c.Double(nullable: false),
                        ErShouCheXiaoShouShuLiang = c.Double(nullable: false),
                        ZhuYingYeWuShouRu = c.Double(nullable: false),
                        ZhuYingShouRu_ZhengChe = c.Double(nullable: false),
                        ZhuYingShouRu_ShouHouWeiXiu = c.Double(nullable: false),
                        ZhuYingShouRu_WeiXiuPeiJian = c.Double(nullable: false),
                        ZhuYingShouRu_GongShi = c.Double(nullable: false),
                        ZhuYingShouRu_ZhuangShiZhuangHuang = c.Double(nullable: false),
                        ZhuYingShouRu_YongJin = c.Double(nullable: false),
                        ZhuYingShouRu_FenQi = c.Double(nullable: false),
                        ZhuYingShouRu_BaoXian = c.Double(nullable: false),
                        ZhuYingShouRu_XinBao = c.Double(nullable: false),
                        ZhuYingShouRu_XuBao = c.Double(nullable: false),
                        ZhuYingShouRu_YanBao = c.Double(),
                        ZhuYingShouRu_GuaPai = c.Double(nullable: false),
                        ZhuYingShouRu_ErShouChe = c.Double(nullable: false),
                        ZhuYingShouRu_QiTa = c.Double(),
                        ZhuYingYeWuChengBen = c.Double(nullable: false),
                        ZhuYingChengBen_ZhengChe = c.Double(nullable: false),
                        ZhuYingChengBen_ShouHouWeiXiu = c.Double(nullable: false),
                        ZhuYingChengBen_WeiXiuPeiJian = c.Double(nullable: false),
                        ZhuYingChengBen_GongShi = c.Double(),
                        ZhuYingChengBen_ZhuangShiZhuangHuang = c.Double(nullable: false),
                        ZhuYingChengBen_YongJin = c.Double(),
                        ZhuYingChengBen_FenQi = c.Double(),
                        ZhuYingChengBen_BaoXian = c.Double(),
                        ZhuYingChengBen_XinBao = c.Double(),
                        ZhuYingChengBen_XuBao = c.Double(),
                        ZhuYingChengBen_YanBao = c.Double(),
                        ZhuYingChengBen_GuaPai = c.Double(),
                        ZhuYingChengBen_ErShouChe = c.Double(),
                        ZhuYingChengBen_QiTa = c.Double(),
                        MaoLi = c.Double(nullable: false),
                        MaoLi_ZhengChe = c.Double(nullable: false),
                        MaoLi_WeiXiu = c.Double(nullable: false),
                        MaoLi_ZhuangShiZhuangHuang = c.Double(nullable: false),
                        MaoLi_YongJin = c.Double(nullable: false),
                        ZhuYingYeWuShueiJinJiFuJia = c.Double(nullable: false),
                        ZhuYingYeWuFuJiaShuiHouMaoLi = c.Double(nullable: false),
                        QiTaYeWuShouRu = c.Double(),
                        QiTaYeWuChengBen = c.Double(),
                        QiTaYeWuShuiJinJiFuJia = c.Double(),
                        QiTaYeWuLiRun = c.Double(),
                        XiaoShouJiGuanLiFeiYong = c.Double(nullable: false),
                        XiShueiQianLiRun = c.Double(nullable: false),
                        CaiWuFeiYong = c.Double(nullable: false),
                        YingYeLiRun = c.Double(nullable: false),
                        ZiChanJianZhiSunShi = c.Double(),
                        GongYunJiaZhiBianDongShouYi = c.Double(),
                        TouZiShouYi = c.Double(),
                        YingYeWaiShouZhiJingE = c.Double(),
                        LiRunZongE = c.Double(nullable: false),
                        SuoDeShui = c.Double(),
                        ShueiHouLiRun = c.Double(nullable: false),
                        ShaoShuGuDongSunYi = c.Double(),
                        JingLiRun = c.Double(nullable: false),
                        ProfitLossReality_MainID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.ProfitLoss_Main", t => t.ProfitLoss_MainID)
                .Index(t => t.CompanyID)
                .Index(t => t.ProfitLoss_MainID);
            
            CreateTable(
                "dbo.ProfitLoss_Main",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        ParticularYearID = c.Int(nullable: false),
                        IsReport = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.ParticularYear", t => t.ParticularYearID)
                .Index(t => t.CompanyID)
                .Index(t => t.ParticularYearID);
            
            CreateTable(
                "dbo.ParticularYear",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProfitLossReality_Detail",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProfitLossReality_MainID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        ParticularYearID = c.Int(nullable: false),
                        Week = c.Int(nullable: false),
                        XiaoShouShuLiang = c.Double(nullable: false),
                        XinCheXiaoShouShuLiang = c.Double(nullable: false),
                        WeiXiuJinChangTaiCi = c.Double(nullable: false),
                        FenQiShuLiang = c.Double(nullable: false),
                        XinBaoShuLiang = c.Double(nullable: false),
                        XuBaoShuLiang = c.Double(nullable: false),
                        YanBaoShuLiang = c.Double(),
                        GuaPaiShuLiang = c.Double(nullable: false),
                        ErShouCheXiaoShouShuLiang = c.Double(nullable: false),
                        ZhuYingYeWuShouRu = c.Double(nullable: false),
                        ZhuYingShouRu_ZhengChe = c.Double(nullable: false),
                        ZhuYingShouRu_ShouHouWeiXiu = c.Double(nullable: false),
                        ZhuYingShouRu_WeiXiuPeiJian = c.Double(nullable: false),
                        ZhuYingShouRu_GongShi = c.Double(nullable: false),
                        ZhuYingShouRu_ZhuangShiZhuangHuang = c.Double(nullable: false),
                        ZhuYingShouRu_YongJin = c.Double(nullable: false),
                        ZhuYingShouRu_FenQi = c.Double(nullable: false),
                        ZhuYingShouRu_BaoXian = c.Double(nullable: false),
                        ZhuYingShouRu_XinBao = c.Double(nullable: false),
                        ZhuYingShouRu_XuBao = c.Double(nullable: false),
                        ZhuYingShouRu_YanBao = c.Double(),
                        ZhuYingShouRu_GuaPai = c.Double(nullable: false),
                        ZhuYingShouRu_ErShouChe = c.Double(nullable: false),
                        ZhuYingShouRu_QiTa = c.Double(),
                        ZhuYingYeWuChengBen = c.Double(nullable: false),
                        ZhuYingChengBen_ZhengChe = c.Double(nullable: false),
                        ZhuYingChengBen_ShouHouWeiXiu = c.Double(nullable: false),
                        ZhuYingChengBen_WeiXiuPeiJian = c.Double(nullable: false),
                        ZhuYingChengBen_GongShi = c.Double(),
                        ZhuYingChengBen_ZhuangShiZhuangHuang = c.Double(nullable: false),
                        ZhuYingChengBen_YongJin = c.Double(),
                        ZhuYingChengBen_FenQi = c.Double(),
                        ZhuYingChengBen_BaoXian = c.Double(),
                        ZhuYingChengBen_XinBao = c.Double(),
                        ZhuYingChengBen_XuBao = c.Double(),
                        ZhuYingChengBen_YanBao = c.Double(),
                        ZhuYingChengBen_GuaPai = c.Double(),
                        ZhuYingChengBen_ErShouChe = c.Double(),
                        ZhuYingChengBen_QiTa = c.Double(),
                        MaoLi = c.Double(nullable: false),
                        MaoLi_ZhengChe = c.Double(nullable: false),
                        MaoLi_WeiXiu = c.Double(nullable: false),
                        MaoLi_ZhuangShiZhuangHuang = c.Double(nullable: false),
                        MaoLi_YongJin = c.Double(nullable: false),
                        ZhuYingYeWuShueiJinJiFuJia = c.Double(nullable: false),
                        ZhuYingYeWuFuJiaShuiHouMaoLi = c.Double(nullable: false),
                        QiTaYeWuShouRu = c.Double(),
                        QiTaYeWuChengBen = c.Double(),
                        QiTaYeWuShuiJinJiFuJia = c.Double(),
                        QiTaYeWuLiRun = c.Double(),
                        XiaoShouJiGuanLiFeiYong = c.Double(nullable: false),
                        XiShueiQianLiRun = c.Double(nullable: false),
                        CaiWuFeiYong = c.Double(nullable: false),
                        YingYeLiRun = c.Double(nullable: false),
                        ZiChanJianZhiSunShi = c.Double(),
                        GongYunJiaZhiBianDongShouYi = c.Double(),
                        TouZiShouYi = c.Double(),
                        YingYeWaiShouZhiJingE = c.Double(),
                        LiRunZongE = c.Double(nullable: false),
                        SuoDeShui = c.Double(),
                        ShueiHouLiRun = c.Double(nullable: false),
                        ShaoShuGuDongSunYi = c.Double(),
                        JingLiRun = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.ParticularYear", t => t.ParticularYearID)
                .ForeignKey("dbo.ProfitLossReality_Main", t => t.ProfitLossReality_MainID, cascadeDelete: true)
                .Index(t => t.ProfitLossReality_MainID)
                .Index(t => t.CompanyID)
                .Index(t => t.ParticularYearID);
            
            CreateTable(
                "dbo.ProfitLossReality_Main",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        ParticularYearID = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        IsReport = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .ForeignKey("dbo.ParticularYear", t => t.ParticularYearID)
                .ForeignKey("dbo.ProfitLoss_Detailed", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.CompanyID)
                .Index(t => t.ParticularYearID);


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
            DropForeignKey("dbo.ProfitLoss_Detailed", "ProfitLoss_MainID", "dbo.ProfitLoss_Main");
            DropForeignKey("dbo.ProfitLossReality_Detail", "ProfitLossReality_MainID", "dbo.ProfitLossReality_Main");
            DropForeignKey("dbo.ProfitLossReality_Main", "ID", "dbo.ProfitLoss_Detailed");
            DropForeignKey("dbo.ProfitLossReality_Main", "ParticularYearID", "dbo.ParticularYear");
            DropForeignKey("dbo.ProfitLossReality_Main", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.ProfitLossReality_Detail", "ParticularYearID", "dbo.ParticularYear");
            DropForeignKey("dbo.ProfitLossReality_Detail", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.ProfitLoss_Main", "ParticularYearID", "dbo.ParticularYear");
            DropForeignKey("dbo.ProfitLoss_Main", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.ProfitLoss_Detailed", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.ProfitLoss_Coefficient", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.RoleMenu", "RoleID", "dbo.Role");
            DropForeignKey("dbo.RoleMenu", "MenuID", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentMenuID", "dbo.Menu");
            DropForeignKey("dbo.RoleOption", "RoleID", "dbo.Role");
            DropForeignKey("dbo.RoleOption", "MenuOptionID", "dbo.MenuOption");
            DropForeignKey("dbo.MenuOption", "MenuID", "dbo.Menu");
            DropForeignKey("dbo.RoleAccount", "RoleID", "dbo.Role");
            DropForeignKey("dbo.RoleAccount", "GroupAccountID", "dbo.GroupAccount");
            DropForeignKey("dbo.GroupAccount", "GroupID", "dbo.Group");
            DropForeignKey("dbo.Company", "GroupID", "dbo.Group");
            DropForeignKey("dbo.RoleAccount", "CompanyAccountID", "dbo.CompanyAccount");
            DropForeignKey("dbo.CompanyAccount", "CompanyID", "dbo.Company");
            DropIndex("dbo.ProfitLossReality_Main", new[] { "ParticularYearID" });
            DropIndex("dbo.ProfitLossReality_Main", new[] { "CompanyID" });
            DropIndex("dbo.ProfitLossReality_Main", new[] { "ID" });
            DropIndex("dbo.ProfitLossReality_Detail", new[] { "ParticularYearID" });
            DropIndex("dbo.ProfitLossReality_Detail", new[] { "CompanyID" });
            DropIndex("dbo.ProfitLossReality_Detail", new[] { "ProfitLossReality_MainID" });
            DropIndex("dbo.ProfitLoss_Main", new[] { "ParticularYearID" });
            DropIndex("dbo.ProfitLoss_Main", new[] { "CompanyID" });
            DropIndex("dbo.ProfitLoss_Detailed", new[] { "ProfitLoss_MainID" });
            DropIndex("dbo.ProfitLoss_Detailed", new[] { "CompanyID" });
            DropIndex("dbo.ProfitLoss_Coefficient", new[] { "CompanyID" });
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
            DropIndex("dbo.Company", new[] { "GroupID" });
            DropTable("dbo.ProfitLossReality_Main");
            DropTable("dbo.ProfitLossReality_Detail");
            DropTable("dbo.ParticularYear");
            DropTable("dbo.ProfitLoss_Main");
            DropTable("dbo.ProfitLoss_Detailed");
            DropTable("dbo.ProfitLoss_Coefficient");
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
            DropTable("dbo.BudgetClass");
        }
    }
}
