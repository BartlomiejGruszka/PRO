namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeratorNullableDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Moderators", "LastLoginDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Moderators", "LastLoginDate", c => c.DateTime(nullable: false));
        }
    }
}
