namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class game_foreign_keys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "PlatformId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "SeriesId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "PublisherId", c => c.Int());
            AddColumn("dbo.Games", "DeveloperId", c => c.Int());
            CreateIndex("dbo.Games", "PlatformId");
            CreateIndex("dbo.Games", "StatusId");
            CreateIndex("dbo.Games", "GenreId");
            CreateIndex("dbo.Games", "SeriesId");
            CreateIndex("dbo.Games", "PublisherId");
            CreateIndex("dbo.Games", "DeveloperId");
            AddForeignKey("dbo.Games", "DeveloperId", "dbo.Companies", "Id");
            AddForeignKey("dbo.Games", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "PlatformId", "dbo.Platforms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "PublisherId", "dbo.Companies", "Id");
            AddForeignKey("dbo.Games", "SeriesId", "dbo.Series", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Games", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Games", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.Games", "PublisherId", "dbo.Companies");
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Games", "DeveloperId", "dbo.Companies");
            DropIndex("dbo.Games", new[] { "DeveloperId" });
            DropIndex("dbo.Games", new[] { "PublisherId" });
            DropIndex("dbo.Games", new[] { "SeriesId" });
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropIndex("dbo.Games", new[] { "StatusId" });
            DropIndex("dbo.Games", new[] { "PlatformId" });
            DropColumn("dbo.Games", "DeveloperId");
            DropColumn("dbo.Games", "PublisherId");
            DropColumn("dbo.Games", "SeriesId");
            DropColumn("dbo.Games", "GenreId");
            DropColumn("dbo.Games", "StatusId");
            DropColumn("dbo.Games", "PlatformId");
        }
    }
}
