namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleData2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"            
            INSERT INTO [dbo].[Moderators] ([CreatedDate],[LastLoginDate],[UserId],[IsActive]) values (N'1999-01-01 17:00:00', NULL,8,1)
            INSERT INTO [dbo].[Moderators] ([CreatedDate],[LastLoginDate],[UserId],[IsActive]) values (N'1999-01-01 17:00:00', NULL,9,1)     
            ");

            Sql(@"
            INSERT INTO [dbo].[Authors] ([FirstName],[LastName],[CreatedDate],[UserId],[IsActive]) values ('Jan','Kowalski', N'1999-01-01 17:00:00',7,1)
            INSERT INTO [dbo].[Authors] ([FirstName],[LastName],[CreatedDate],[UserId],[IsActive]) values ('Adam','Nowak', N'1999-01-01 17:00:00',9,1)
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Awards] ON
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (1,'Gra roku 2007', N'2007-01-01 17:00:00',1)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (2,'Gra roku 2010', N'2010-01-01 17:00:00',2)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (3,'Gra roku 2012', N'2012-01-01 17:00:00',3)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (4,'Najlepsza fabu³a 2009', N'2009-01-01 17:00:00',5)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (5,'Najlepsza fabu³a 2012', N'2012-01-01 17:00:00',3)
            SET IDENTITY_INSERT [dbo].[Awards] OFF
            ");

            Sql(@"
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,1)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (2,1)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (3,1)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,2)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (2,3)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (4,3)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (6,4)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (7,4)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (8,4)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,4)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,5)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (3,5)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (7,5)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,6)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (2,6)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,7)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,8)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (2,8)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,9)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (2,9)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (4,9)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,10)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (2,10)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (3,10)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (4,10)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (6,10)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (1,11)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (3,11)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (5,12)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (7,13)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (8,13)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (2,14)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (3,14)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (4,14)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (5,14)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (6,14)
            INSERT INTO [dbo].[LanguageGames] ([Language_Id],[Game_Id]) values (7,14)
            ");

            Sql(@"
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (2,1)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (3,1)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,1)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (2,2)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (3,2)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,2)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (2,3)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (3,3)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,3)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (2,4)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (4,4)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,4)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (2,5)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (4,5)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,5)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (2,12)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (4,12)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,12)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (4,6)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (9,7)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (7,7)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (7,8)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (9,8)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (1,9)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (3,9)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (4,9)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (5,9)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,9)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (3,10)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (4,10)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (2,10)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (9,10)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (3,11)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (4,11)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (2,11)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,11)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (5,13)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (8,13)
            INSERT INTO [dbo].[TagGames] ([Tag_Id],[Game_Id]) values (5,14)
            SET IDENTITY_INSERT [dbo].[TagGames] OFF
            ");



        }
        
        public override void Down()
        {
        }
    }
}
