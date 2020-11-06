namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagemodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "ImageId", c => c.Int());
            AlterColumn("dbo.Games", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Games", "Description", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Reviews", "Content", c => c.String(nullable: false, maxLength: 1000));
            CreateIndex("dbo.Games", "ImageId");
            AddForeignKey("dbo.Games", "ImageId", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "ImageId", "dbo.Images");
            DropIndex("dbo.Games", new[] { "ImageId" });
            AlterColumn("dbo.Reviews", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Description", c => c.String());
            AlterColumn("dbo.Games", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Games", "ImageId");
            DropTable("dbo.Images");
        }
    }
}
