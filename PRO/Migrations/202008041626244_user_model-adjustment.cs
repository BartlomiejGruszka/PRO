namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_modeladjustment : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "UserId");
            AddForeignKey("dbo.Users", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "UserId" });
        }
    }
}
