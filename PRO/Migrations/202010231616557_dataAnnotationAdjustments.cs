namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotationAdjustments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Paragraphs", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Paragraphs", new[] { "ArticleId" });
            AlterColumn("dbo.Reviews", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Platforms", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Languages", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Series", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 100));
            DropTable("dbo.Paragraphs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Paragraphs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Status", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Series", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Languages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Platforms", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Content", c => c.String(nullable: false, maxLength: 1000));
            CreateIndex("dbo.Paragraphs", "ArticleId");
            AddForeignKey("dbo.Paragraphs", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
