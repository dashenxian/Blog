namespace BlogRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        Author = c.String(maxLength: 256),
                        IsPublish = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
