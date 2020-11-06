namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clearData1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GameLanguages");
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
            
            AddPrimaryKey("dbo.GameLanguages", new[] { "GameId", "LanguageId" });
            DropColumn("dbo.GameLanguages", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameLanguages", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.LanguageGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.LanguageGames", "Language_Id", "dbo.Languages");
            DropIndex("dbo.LanguageGames", new[] { "Game_Id" });
            DropIndex("dbo.LanguageGames", new[] { "Language_Id" });
            DropPrimaryKey("dbo.GameLanguages");
            DropTable("dbo.LanguageGames");
            AddPrimaryKey("dbo.GameLanguages", "Id");
        }
    }
}
