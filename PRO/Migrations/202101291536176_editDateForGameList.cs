namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDateForGameList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameLists", "EditedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameLists", "EditedDate");
        }
    }
}
