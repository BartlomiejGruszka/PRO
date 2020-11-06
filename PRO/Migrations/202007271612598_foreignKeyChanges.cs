namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameLanguages", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.GameLanguages", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.GameTags", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.GameTags", "TagId", c => c.Int(nullable: false));
            CreateIndex("dbo.GameLanguages", "GameId");
            CreateIndex("dbo.GameLanguages", "LanguageId");
            CreateIndex("dbo.GameTags", "GameId");
            CreateIndex("dbo.GameTags", "TagId");
            AddForeignKey("dbo.GameLanguages", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GameLanguages", "LanguageId", "dbo.Languages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GameTags", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GameTags", "TagId", "dbo.Languages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GameTags", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.GameTags", "TagId", "dbo.Languages");
            DropForeignKey("dbo.GameTags", "GameId", "dbo.Games");
            DropForeignKey("dbo.GameLanguages", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.GameLanguages", "GameId", "dbo.Games");
            DropIndex("dbo.GameTags", new[] { "TagId" });
            DropIndex("dbo.GameTags", new[] { "GameId" });
            DropIndex("dbo.GameLanguages", new[] { "LanguageId" });
            DropIndex("dbo.GameLanguages", new[] { "GameId" });
            DropColumn("dbo.GameTags", "TagId");
            DropColumn("dbo.GameTags", "GameId");
            DropColumn("dbo.GameLanguages", "LanguageId");
            DropColumn("dbo.GameLanguages", "GameId");
        }
    }
}
