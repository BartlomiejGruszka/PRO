namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class review_relations1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Login");
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Login", c => c.String(nullable: false));
        }
    }
}
