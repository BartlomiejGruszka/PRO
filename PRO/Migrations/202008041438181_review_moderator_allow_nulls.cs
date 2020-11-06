namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class review_moderator_allow_nulls : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators");
            DropIndex("dbo.Reviews", new[] { "ModeratorId" });
            AlterColumn("dbo.Reviews", "EditDate", c => c.DateTime());
            AlterColumn("dbo.Reviews", "ModeratorId", c => c.Int());
            CreateIndex("dbo.Reviews", "ModeratorId");
            AddForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators");
            DropIndex("dbo.Reviews", new[] { "ModeratorId" });
            AlterColumn("dbo.Reviews", "ModeratorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "EditDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Reviews", "ModeratorId");
            AddForeignKey("dbo.Reviews", "ModeratorId", "dbo.Moderators", "UserId", cascadeDelete: true);
        }
    }
}
