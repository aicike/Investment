namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkFlow_Node", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkFlow_Node", "Remark");
        }
    }
}
