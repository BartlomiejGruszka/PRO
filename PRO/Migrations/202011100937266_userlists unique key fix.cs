namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userlistsuniquekeyfix : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            ALTER TABLE dbo.UserLists
            DROP CONSTRAINT UserLists_ak_1          
            ");
            Sql(@"
            ALTER TABLE dbo.UserLists
            ADD CONSTRAINT UserLists_ak_1 UNIQUE (UserId, Name)           
            ");
        }
        
        public override void Down()
        {

        }
    }
}
