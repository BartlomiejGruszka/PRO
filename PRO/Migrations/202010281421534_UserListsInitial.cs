namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserListsInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGameLists", "GameId", "dbo.Games");
            DropForeignKey("dbo.Lists", "ListTypeId", "dbo.ListTypes");
            DropForeignKey("dbo.UserGameLists", "ListId", "dbo.Lists");
            DropForeignKey("dbo.UserGameLists", "UserId", "dbo.Users");
            DropIndex("dbo.UserGameLists", new[] { "UserId" });
            DropIndex("dbo.UserGameLists", new[] { "ListId" });
            DropIndex("dbo.UserGameLists", new[] { "GameId" });
            DropIndex("dbo.Lists", new[] { "ListTypeId" });
            CreateTable(
                "dbo.GameLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddedDate = c.DateTime(nullable: false),
                        HoursPlayed = c.Int(nullable: false),
                        PersonalScore = c.Int(nullable: false),
                        UserListId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.UserLists", t => t.UserListId, cascadeDelete: true)
                .Index(t => t.UserListId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.UserLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsPublic = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        ListTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListTypes", t => t.ListTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ListTypeId);
            
            AlterColumn("dbo.ListTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            DropTable("dbo.UserGameLists");
            DropTable("dbo.Lists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        ListTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserGameLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoursPlayed = c.Int(),
                        PersonalScore = c.Int(),
                        UserId = c.Int(nullable: false),
                        ListId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UserLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLists", "ListTypeId", "dbo.ListTypes");
            DropForeignKey("dbo.GameLists", "UserListId", "dbo.UserLists");
            DropForeignKey("dbo.GameLists", "GameId", "dbo.Games");
            DropIndex("dbo.UserLists", new[] { "ListTypeId" });
            DropIndex("dbo.UserLists", new[] { "UserId" });
            DropIndex("dbo.GameLists", new[] { "GameId" });
            DropIndex("dbo.GameLists", new[] { "UserListId" });
            AlterColumn("dbo.ListTypes", "Name", c => c.String(nullable: false));
            DropTable("dbo.UserLists");
            DropTable("dbo.GameLists");
            CreateIndex("dbo.Lists", "ListTypeId");
            CreateIndex("dbo.UserGameLists", "GameId");
            CreateIndex("dbo.UserGameLists", "ListId");
            CreateIndex("dbo.UserGameLists", "UserId");
            AddForeignKey("dbo.UserGameLists", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserGameLists", "ListId", "dbo.Lists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lists", "ListTypeId", "dbo.ListTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserGameLists", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
