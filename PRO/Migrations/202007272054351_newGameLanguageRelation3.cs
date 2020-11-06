namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newGameLanguageRelation3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameLanguages", "GameId", "dbo.Games");
            DropForeignKey("dbo.GameLanguages", "LanguageId", "dbo.Languages");
            DropIndex("dbo.GameLanguages", new[] { "GameId" });
            DropIndex("dbo.GameLanguages", new[] { "LanguageId" });
            CreateTable(
                "dbo.LanguageGames",
                c => new
                    {
                        Language_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language_Id, t.Game_Id })
                .ForeignKey("dbo.Languages", t => t.Language_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Language_Id)
                .Index(t => t.Game_Id);
            
            DropTable("dbo.GameLanguages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameLanguages",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.LanguageId });
            
            DropForeignKey("dbo.LanguageGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.LanguageGames", "Language_Id", "dbo.Languages");
            DropIndex("dbo.LanguageGames", new[] { "Game_Id" });
            DropIndex("dbo.LanguageGames", new[] { "Language_Id" });
            DropTable("dbo.LanguageGames");
            CreateIndex("dbo.GameLanguages", "LanguageId");
            CreateIndex("dbo.GameLanguages", "GameId");
            AddForeignKey("dbo.GameLanguages", "LanguageId", "dbo.Languages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GameLanguages", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
