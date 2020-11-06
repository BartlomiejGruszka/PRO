namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remaining_foreign_keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.Moderators");
            AddColumn("dbo.Articles", "Content", c => c.String(nullable: false));
            AddColumn("dbo.Articles", "ImageId", c => c.Int());
            AddColumn("dbo.Articles", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "ArticleTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.ArticleTypes", "ArticleType_Id", c => c.Int());
            AddColumn("dbo.Authors", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Moderators", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "ImageId", c => c.Int());
            AddColumn("dbo.Lists", "ListTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Paragraphs", "ArticleId", c => c.Int(nullable: false));
            AddColumn("dbo.UserGameLists", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.UserGameLists", "ListId", c => c.Int(nullable: false));
            AddColumn("dbo.UserGameLists", "GameId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserGameLists", "HoursPlayed", c => c.Int());
            AlterColumn("dbo.UserGameLists", "PersonalScore", c => c.Int());
            AddPrimaryKey("dbo.Authors", "UserId");
            AddPrimaryKey("dbo.Moderators", "UserId");
            CreateIndex("dbo.Articles", "ImageId");
            CreateIndex("dbo.Articles", "GameId");
            CreateIndex("dbo.Articles", "UserId");
            CreateIndex("dbo.Articles", "ArticleTypeId");
            CreateIndex("dbo.ArticleTypes", "ArticleType_Id");
            CreateIndex("dbo.Authors", "UserId");
            CreateIndex("dbo.Users", "ImageId");
            CreateIndex("dbo.UserGameLists", "UserId");
            CreateIndex("dbo.UserGameLists", "ListId");
            CreateIndex("dbo.UserGameLists", "GameId");
            CreateIndex("dbo.Lists", "ListTypeId");
            CreateIndex("dbo.Moderators", "UserId");
            CreateIndex("dbo.Paragraphs", "ArticleId");
            AddForeignKey("dbo.ArticleTypes", "ArticleType_Id", "dbo.ArticleTypes", "Id");
            AddForeignKey("dbo.Articles", "ArticleTypeId", "dbo.ArticleTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "UserId", "dbo.Authors", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "ImageId", "dbo.Images", "Id");
            AddForeignKey("dbo.Articles", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserGameLists", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lists", "ListTypeId", "dbo.ListTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserGameLists", "ListId", "dbo.Lists", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserGameLists", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Moderators", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Authors", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Articles", "ImageId", "dbo.Images", "Id");
            AddForeignKey("dbo.Paragraphs", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators", "UserId", cascadeDelete: true);
            DropColumn("dbo.Authors", "User_Id");
            DropColumn("dbo.Moderators", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Moderators", "User_Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Authors", "User_Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators");
            DropForeignKey("dbo.Paragraphs", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Authors", "UserId", "dbo.Users");
            DropForeignKey("dbo.Moderators", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserGameLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserGameLists", "ListId", "dbo.Lists");
            DropForeignKey("dbo.Lists", "ListTypeId", "dbo.ListTypes");
            DropForeignKey("dbo.UserGameLists", "GameId", "dbo.Games");
            DropForeignKey("dbo.Articles", "GameId", "dbo.Games");
            DropForeignKey("dbo.Users", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Articles", "UserId", "dbo.Authors");
            DropForeignKey("dbo.Articles", "ArticleTypeId", "dbo.ArticleTypes");
            DropForeignKey("dbo.ArticleTypes", "ArticleType_Id", "dbo.ArticleTypes");
            DropIndex("dbo.Paragraphs", new[] { "ArticleId" });
            DropIndex("dbo.Moderators", new[] { "UserId" });
            DropIndex("dbo.Lists", new[] { "ListTypeId" });
            DropIndex("dbo.UserGameLists", new[] { "GameId" });
            DropIndex("dbo.UserGameLists", new[] { "ListId" });
            DropIndex("dbo.UserGameLists", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "ImageId" });
            DropIndex("dbo.Authors", new[] { "UserId" });
            DropIndex("dbo.ArticleTypes", new[] { "ArticleType_Id" });
            DropIndex("dbo.Articles", new[] { "ArticleTypeId" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropIndex("dbo.Articles", new[] { "GameId" });
            DropIndex("dbo.Articles", new[] { "ImageId" });
            DropPrimaryKey("dbo.Moderators");
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.UserGameLists", "PersonalScore", c => c.Int(nullable: false));
            AlterColumn("dbo.UserGameLists", "HoursPlayed", c => c.Int(nullable: false));
            DropColumn("dbo.UserGameLists", "GameId");
            DropColumn("dbo.UserGameLists", "ListId");
            DropColumn("dbo.UserGameLists", "UserId");
            DropColumn("dbo.Paragraphs", "ArticleId");
            DropColumn("dbo.Lists", "ListTypeId");
            DropColumn("dbo.Users", "ImageId");
            DropColumn("dbo.Moderators", "UserId");
            DropColumn("dbo.Authors", "UserId");
            DropColumn("dbo.ArticleTypes", "ArticleType_Id");
            DropColumn("dbo.Articles", "ArticleTypeId");
            DropColumn("dbo.Articles", "UserId");
            DropColumn("dbo.Articles", "GameId");
            DropColumn("dbo.Articles", "ImageId");
            DropColumn("dbo.Articles", "Content");
            AddPrimaryKey("dbo.Moderators", "User_Id");
            AddPrimaryKey("dbo.Authors", "User_Id");
            AddForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators", "User_Id", cascadeDelete: true);
        }
    }
}
