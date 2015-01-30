namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Company", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "ChengLiShiJianJiYingYeQiXian", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "JingYingFanWei", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "QiYeZiZhi", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Company", "QiYeZiZhi", c => c.String(nullable: false));
            AlterColumn("dbo.Company", "JingYingFanWei", c => c.String());
            AlterColumn("dbo.Company", "ChengLiShiJianJiYingYeQiXian", c => c.String());
            AlterColumn("dbo.Company", "Phone", c => c.String());
        }
    }
}
