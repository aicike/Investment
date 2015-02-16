namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlow", "JSON_Owner_A_ID", c => c.Int());
            AddColumn("dbo.WorkFlow", "JSON_Owner_B_ID", c => c.Int());
            CreateIndex("dbo.WorkFlow", "JSON_Owner_A_ID");
            CreateIndex("dbo.WorkFlow", "JSON_Owner_B_ID");
            AddForeignKey("dbo.WorkFlow", "JSON_Owner_A_ID", "dbo.GroupAccount", "ID");
            AddForeignKey("dbo.WorkFlow", "JSON_Owner_B_ID", "dbo.GroupAccount", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkFlow", "JSON_Owner_B_ID", "dbo.GroupAccount");
            DropForeignKey("dbo.WorkFlow", "JSON_Owner_A_ID", "dbo.GroupAccount");
            DropIndex("dbo.WorkFlow", new[] { "JSON_Owner_B_ID" });
            DropIndex("dbo.WorkFlow", new[] { "JSON_Owner_A_ID" });
            DropColumn("dbo.WorkFlow", "JSON_Owner_B_ID");
            DropColumn("dbo.WorkFlow", "JSON_Owner_A_ID");
        }
    }
}
