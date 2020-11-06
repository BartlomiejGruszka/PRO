namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newGameTagRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameTags", "GameId", "dbo.Games");
            DropForeignKey("dbo.GameTags", "TagId", "dbo.Tags");
            DropIndex("dbo.GameTags", new[] { "GameId" });
            DropIndex("dbo.GameTags", new[] { "TagId" });
            CreateTable(
                "dbo.TagGames",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Game_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Game_Id);
            
            DropTable("dbo.GameTags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TagGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.TagGames", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagGames", new[] { "Game_Id" });
            DropIndex("dbo.TagGames", new[] { "Tag_Id" });
            DropTable("dbo.TagGames");
            CreateIndex("dbo.GameTags", "TagId");
            CreateIndex("dbo.GameTags", "GameId");
            AddForeignKey("dbo.GameTags", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GameTags", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
