namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "ImagePath", c => c.String(nullable: false));
        }
    }
}
