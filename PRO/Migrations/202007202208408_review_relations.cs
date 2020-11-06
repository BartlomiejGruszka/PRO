namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class review_relations : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Reviews", "EditDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "GameplayScore", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "ModeratorId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "User_Id", c => c.Int());
            CreateIndex("dbo.Reviews", "UserId");
            CreateIndex("dbo.Reviews", "GameId");
            CreateIndex("dbo.Reviews", "ModeratorId");
            CreateIndex("dbo.AspNetUsers", "User_Id");
            AddForeignKey("dbo.Reviews", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators", "User_Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Reviews", "GameplayScorere");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "GameplayScorere", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators");
            DropForeignKey("dbo.Reviews", "GameId", "dbo.Games");
            DropIndex("dbo.AspNetUsers", new[] { "User_Id" });
            DropIndex("dbo.Reviews", new[] { "ModeratorId" });
            DropIndex("dbo.Reviews", new[] { "GameId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "User_Id");
            DropColumn("dbo.Reviews", "ModeratorId");
            DropColumn("dbo.Reviews", "GameId");
            DropColumn("dbo.Reviews", "UserId");
            DropColumn("dbo.Reviews", "GameplayScore");
            DropColumn("dbo.Reviews", "EditDate");
            DropTable("dbo.Users");
        }
    }
}
