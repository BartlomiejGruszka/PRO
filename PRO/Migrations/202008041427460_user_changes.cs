namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "User_Id", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "User_Id" });
            AddColumn("dbo.Users", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AspNetUsers", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "User_Id", c => c.Int());
            DropColumn("dbo.Users", "UserId");
            CreateIndex("dbo.AspNetUsers", "User_Id");
            AddForeignKey("dbo.AspNetUsers", "User_Id", "dbo.Users", "Id");
        }
    }
}
