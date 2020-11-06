namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class uniqueconstraints : DbMigration
    {
        public override void Up()
        {

            Sql(@"
            ALTER TABLE dbo.ArticleTypes
            ADD CONSTRAINT ArticleType_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.Awards
            ADD CONSTRAINT Awards_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.Companies
            ADD CONSTRAINT Companies_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.GameLists
            ADD CONSTRAINT GameLists_ak_1 UNIQUE (UserListId,GameId)           
            ");

            Sql(@"
            ALTER TABLE dbo.Genres
            ADD CONSTRAINT Genres_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.Images
            ADD CONSTRAINT Images_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.Languages
            ADD CONSTRAINT Languages_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.ListTypes
            ADD CONSTRAINT ListTypes_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.Platforms
            ADD CONSTRAINT Platforms_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.Series
            ADD CONSTRAINT Series_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.Status
            ADD CONSTRAINT Status_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.Tags
            ADD CONSTRAINT Tags_ak_1 UNIQUE (Name)           
            ");

            Sql(@"
            ALTER TABLE dbo.UserLists
            ADD CONSTRAINT UserLists_ak_1 UNIQUE (Name)           
            ");
        }

        public override void Down()
        {
        }
    }
}
