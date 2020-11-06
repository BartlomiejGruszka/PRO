namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataannotationsforgenremodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
        }
    }
}
