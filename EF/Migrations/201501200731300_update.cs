namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MechanismProducts", "WebSite", c => c.String());
            AddColumn("dbo.Mechanism", "WebSite", c => c.String());
            DropColumn("dbo.Mechanism", "Remark");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mechanism", "Remark", c => c.String());
            DropColumn("dbo.Mechanism", "WebSite");
            DropColumn("dbo.MechanismProducts", "WebSite");
        }
    }
}
