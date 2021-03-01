namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleData2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[Moderators] ON
            INSERT INTO [dbo].[Moderators] ([CreatedDate],[LastLoginDate],[UserId],[IsActive]) values (N'1999-01-01 17:00:00', NULL,8,1)
            INSERT INTO [dbo].[Moderators] ([CreatedDate],[LastLoginDate],[UserId],[IsActive]) values (N'1999-01-01 17:00:00', NULL,9,1)
            SET IDENTITY_INSERT [dbo].[Moderators] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Authors] ON
            INSERT INTO [dbo].[Authors] ([FirstName],[LastName],[CreatedDate],[UserId],[IsActive]) values ('Jan','Kowalski', N'1999-01-01 17:00:00',7,1)
            INSERT INTO [dbo].[Authors] ([FirstName],[LastName],[CreatedDate],[UserId],[IsActive]) values ('Adam','Nowak', N'1999-01-01 17:00:00',9,1)
            SET IDENTITY_INSERT [dbo].[Authors] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Awards] ON
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (1,'Gra roku 2007', N'2007-01-01 17:00:00',1)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (2,'Gra roku 2010', N'2010-01-01 17:00:00',2)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (2,'Gra roku 2012', N'2012-01-01 17:00:00',3)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (2,'Najlepsza fabu³a 2009', N'2009-01-01 17:00:00',5)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (2,'Najlepsza fabu³a 2012', N'2012-01-01 17:00:00',3)
            SET IDENTITY_INSERT [dbo].[Awards] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[LanguageGames] ON
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
            SET IDENTITY_INSERT [dbo].[LanguageGames] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[TagGames] ON
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

            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5eb5bc6c-173f-4180-aca8-15493310fce2', N'artur@a.pl', 0, N'ABr96KZkKJmwO1/g2tYbMOhxs1sz5Biw1pyhMGUetb4qAymNk8zVAPXBRx6Ep3fjIA==', N'3635fa67-7d1b-4b35-aa54-1f7a63610f14', NULL, 0, 0, NULL, 0, 0, N'Artur')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd800af38-12ff-439a-979e-581590a99dba', N'stefan@a.pl', 0, N'APSCzQCBQayLf0Xcd16eFDPfYxVwxQSB012CYuDljqQDGouhSL62ijPenY4vEDemsw==', N'a5b66d4a-d98a-4d1c-bc71-dfae1f4990a2', NULL, 0, 0, NULL, 0, 0, N'stefan')
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Users] ON
            INSERT INTO[dbo].[Users] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES(10, N'2012-02-20 00:00:00', NULL, 1, 1, NULL, N'd800af38-12ff-439a-979e-581590a99dba')
            INSERT INTO[dbo].[Users] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES(11, N'2021-01-01 00:00:00', NULL, 1, 0, NULL, N'5eb5bc6c-173f-4180-aca8-15493310fce2')
            SET IDENTITY_INSERT[dbo].[Users] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[UserLists] ON
            INSERT INTO[dbo].[UserLists] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES(10, N'2012-02-20 00:00:00', NULL, 1, 1, NULL, N'd800af38-12ff-439a-979e-581590a99dba')
            SET IDENTITY_INSERT[dbo].[UserLists] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[GameLists] ON
            INSERT INTO[dbo].[GameLists] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES(10, N'2012-02-20 00:00:00', NULL, 1, 1, NULL, N'd800af38-12ff-439a-979e-581590a99dba')
            SET IDENTITY_INSERT[dbo].[GameLists] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Reviews] ON
            INSERT INTO[dbo].[Reviews] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES(10, N'2012-02-20 00:00:00', NULL, 1, 1, NULL, N'd800af38-12ff-439a-979e-581590a99dba')
            SET IDENTITY_INSERT[dbo].[Reviews] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Articles] ON
            INSERT INTO[dbo].[Articles] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES(10, N'2012-02-20 00:00:00', NULL, 1, 1, NULL, N'd800af38-12ff-439a-979e-581590a99dba')
            SET IDENTITY_INSERT[dbo].[Articles] OFF
            ");

           

        }
        
        public override void Down()
        {
        }
    }
}
