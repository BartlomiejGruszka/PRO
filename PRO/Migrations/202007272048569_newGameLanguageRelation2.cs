namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newGameLanguageRelation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LanguageGames", "Language_Id", "dbo.Languages");
            DropForeignKey("dbo.LanguageGames", "Game_Id", "dbo.Games");
            DropIndex("dbo.LanguageGames", new[] { "Language_Id" });
            DropIndex("dbo.LanguageGames", new[] { "Game_Id" });
            DropTable("dbo.LanguageGames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LanguageGames",
                c => new
                    {
                        Language_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Language_Id, t.Game_Id });
            
            CreateIndex("dbo.LanguageGames", "Game_Id");
            CreateIndex("dbo.LanguageGames", "Language_Id");
            AddForeignKey("dbo.LanguageGames", "Game_Id", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LanguageGames", "Language_Id", "dbo.Languages", "Id", cascadeDelete: true);
        }
    }
}
