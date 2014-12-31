namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "DaiKuanKa", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "DaiKuanKa");
        }
    }
}
