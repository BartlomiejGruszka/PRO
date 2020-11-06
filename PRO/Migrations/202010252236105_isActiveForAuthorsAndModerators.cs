namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isActiveForAuthorsAndModerators : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Moderators", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Moderators", "IsActive");
            DropColumn("dbo.Authors", "IsActive");
        }
    }
}
