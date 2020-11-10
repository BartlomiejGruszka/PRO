namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniquereviewconstraint : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            ALTER TABLE dbo.Reviews
            ADD CONSTRAINT Review_ak_1 UNIQUE (GameId, UserId)           
            ");
        }
        
        public override void Down()
        {
        }
    }
}
