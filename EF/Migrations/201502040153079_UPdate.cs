namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Company", "IsShow");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "IsShow", c => c.Boolean());
        }
    }
}
