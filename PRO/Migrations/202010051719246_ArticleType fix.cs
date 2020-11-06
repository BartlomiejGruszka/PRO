namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleTypefix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArticleTypes", "ArticleType_Id", "dbo.ArticleTypes");
            DropIndex("dbo.ArticleTypes", new[] { "ArticleType_Id" });
            DropColumn("dbo.ArticleTypes", "ArticleType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArticleTypes", "ArticleType_Id", c => c.Int());
            CreateIndex("dbo.ArticleTypes", "ArticleType_Id");
            AddForeignKey("dbo.ArticleTypes", "ArticleType_Id", "dbo.ArticleTypes", "Id");
        }
    }
}
