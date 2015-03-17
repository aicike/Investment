namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyAccount", "CompanyHistory_ID", "dbo.CompanyHistory");
            DropForeignKey("dbo.CompanyLoan", "CompanyHistory_ID", "dbo.CompanyHistory");
            DropForeignKey("dbo.CompanyReference", "CompanyHistory_ID", "dbo.CompanyHistory");
            DropForeignKey("dbo.CompanyRelation", "CompanyHistory_ID", "dbo.CompanyHistory");
            DropForeignKey("dbo.CompanyRelation", "CompanyHistory_ID1", "dbo.CompanyHistory");
            DropForeignKey("dbo.Financing", "CompanyHistory_ID", "dbo.CompanyHistory");
            DropForeignKey("dbo.CompanyHistory", "IndustryID", "dbo.Industry");
            DropForeignKey("dbo.CompanyHistory", "IndustryLevelID", "dbo.IndustryLevel");
            DropForeignKey("dbo.CompanyHistory", "OwnerID", "dbo.GroupAccount");
            DropForeignKey("dbo.WorkFlow", "CompanyHistory_ID", "dbo.CompanyHistory");
            DropIndex("dbo.CompanyAccount", new[] { "CompanyHistory_ID" });
            DropIndex("dbo.WorkFlow", new[] { "CompanyHistory_ID" });
            DropIndex("dbo.Financing", new[] { "CompanyHistory_ID" });
            DropIndex("dbo.CompanyLoan", new[] { "CompanyHistory_ID" });
            DropIndex("dbo.CompanyReference", new[] { "CompanyHistory_ID" });
            DropIndex("dbo.CompanyRelation", new[] { "CompanyHistory_ID" });
            DropIndex("dbo.CompanyRelation", new[] { "CompanyHistory_ID1" });
            DropIndex("dbo.CompanyHistory", new[] { "OwnerID" });
            DropIndex("dbo.CompanyHistory", new[] { "IndustryID" });
            DropIndex("dbo.CompanyHistory", new[] { "IndustryLevelID" });
            AddColumn("dbo.CompanyHistory", "CreatDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.CompanyHistory", "CreatGroupAccountID", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyAccount", "CompanyHistory_ID");
            DropColumn("dbo.WorkFlow", "CompanyHistory_ID");
            DropColumn("dbo.Financing", "CompanyHistory_ID");
            DropColumn("dbo.CompanyLoan", "CompanyHistory_ID");
            DropColumn("dbo.CompanyReference", "CompanyHistory_ID");
            DropColumn("dbo.CompanyRelation", "CompanyHistory_ID");
            DropColumn("dbo.CompanyRelation", "CompanyHistory_ID1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyRelation", "CompanyHistory_ID1", c => c.Int());
            AddColumn("dbo.CompanyRelation", "CompanyHistory_ID", c => c.Int());
            AddColumn("dbo.CompanyReference", "CompanyHistory_ID", c => c.Int());
            AddColumn("dbo.CompanyLoan", "CompanyHistory_ID", c => c.Int());
            AddColumn("dbo.Financing", "CompanyHistory_ID", c => c.Int());
            AddColumn("dbo.WorkFlow", "CompanyHistory_ID", c => c.Int());
            AddColumn("dbo.CompanyAccount", "CompanyHistory_ID", c => c.Int());
            DropColumn("dbo.CompanyHistory", "CreatGroupAccountID");
            DropColumn("dbo.CompanyHistory", "CreatDateTime");
            CreateIndex("dbo.CompanyHistory", "IndustryLevelID");
            CreateIndex("dbo.CompanyHistory", "IndustryID");
            CreateIndex("dbo.CompanyHistory", "OwnerID");
            CreateIndex("dbo.CompanyRelation", "CompanyHistory_ID1");
            CreateIndex("dbo.CompanyRelation", "CompanyHistory_ID");
            CreateIndex("dbo.CompanyReference", "CompanyHistory_ID");
            CreateIndex("dbo.CompanyLoan", "CompanyHistory_ID");
            CreateIndex("dbo.Financing", "CompanyHistory_ID");
            CreateIndex("dbo.WorkFlow", "CompanyHistory_ID");
            CreateIndex("dbo.CompanyAccount", "CompanyHistory_ID");
            AddForeignKey("dbo.WorkFlow", "CompanyHistory_ID", "dbo.CompanyHistory", "ID");
            AddForeignKey("dbo.CompanyHistory", "OwnerID", "dbo.GroupAccount", "ID");
            AddForeignKey("dbo.CompanyHistory", "IndustryLevelID", "dbo.IndustryLevel", "ID");
            AddForeignKey("dbo.CompanyHistory", "IndustryID", "dbo.Industry", "ID");
            AddForeignKey("dbo.Financing", "CompanyHistory_ID", "dbo.CompanyHistory", "ID");
            AddForeignKey("dbo.CompanyRelation", "CompanyHistory_ID1", "dbo.CompanyHistory", "ID");
            AddForeignKey("dbo.CompanyRelation", "CompanyHistory_ID", "dbo.CompanyHistory", "ID");
            AddForeignKey("dbo.CompanyReference", "CompanyHistory_ID", "dbo.CompanyHistory", "ID");
            AddForeignKey("dbo.CompanyLoan", "CompanyHistory_ID", "dbo.CompanyHistory", "ID");
            AddForeignKey("dbo.CompanyAccount", "CompanyHistory_ID", "dbo.CompanyHistory", "ID");
        }
    }
}
