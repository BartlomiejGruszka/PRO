namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueKeysTest : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GameLists");
            AddPrimaryKey("dbo.GameLists", new[] { "UserListId", "GameId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GameLists");
            AddPrimaryKey("dbo.GameLists", "Id");
        }
    }
}
