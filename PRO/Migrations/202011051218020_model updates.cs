namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelupdates : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GameLists");
            AddColumn("dbo.Articles", "IsActive", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.GameLists", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GameLists");
            DropColumn("dbo.Articles", "IsActive");
            AddPrimaryKey("dbo.GameLists", new[] { "UserListId", "GameId" });
        }
    }
}
