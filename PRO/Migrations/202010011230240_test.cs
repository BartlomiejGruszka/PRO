namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Articles", "SourceLink", c => c.String(maxLength: 255));
            AlterColumn("dbo.ArticleTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Awards", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Awards", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.ArticleTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "SourceLink", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
        }
    }
}
