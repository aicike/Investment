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
                        TableID = c.String(),
                        EnumAttachmentType = c.Int(nullable: false),
                        EnumAttachmentFormat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attachment");
        }
    }
}
