namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameListAnnotationChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameLists", "PersonalScore", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameLists", "PersonalScore", c => c.Int(nullable: false));
        }
    }
}
