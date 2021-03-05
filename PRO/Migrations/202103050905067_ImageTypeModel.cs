namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Images", "ImageTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "ImageTypeId");
            AddForeignKey("dbo.Images", "ImageTypeId", "dbo.ImageTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ImageTypeId", "dbo.ImageTypes");
            DropIndex("dbo.Images", new[] { "ImageTypeId" });
            DropColumn("dbo.Images", "ImageTypeId");
            DropTable("dbo.ImageTypes");
        }
    }
}
