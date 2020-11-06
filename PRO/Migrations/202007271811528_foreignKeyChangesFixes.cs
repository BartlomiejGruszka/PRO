namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyChangesFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameTags", "TagId", "dbo.Languages");
            AddColumn("dbo.Awards", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Platforms", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Awards", "GameId");
            CreateIndex("dbo.Platforms", "CompanyId");
            AddForeignKey("dbo.Awards", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Platforms", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Platforms", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Awards", "GameId", "dbo.Games");
            DropIndex("dbo.Platforms", new[] { "CompanyId" });
            DropIndex("dbo.Awards", new[] { "GameId" });
            DropColumn("dbo.Platforms", "CompanyId");
            DropColumn("dbo.Awards", "GameId");
            AddForeignKey("dbo.GameTags", "TagId", "dbo.Languages", "Id", cascadeDelete: true);
        }
    }
}
