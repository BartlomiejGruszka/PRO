namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticlePrieview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Preview", c => c.String(nullable: false, maxLength: 400));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Preview");
        }
    }
}
