namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a3100c7a-6ef0-43a2-9a48-96d0597677d6', N'aa@a.pl', 0, N'AIHFILFUDlpWP30g7Vetry8AYrQurh4MBSE+1m1m6NwFlq39dItTQdb5BM2w/RXqPg==', N'5988e25e-298f-49bd-85ae-c9536397fef4', NULL, 0, 0, NULL, 0, 0, N'Admin')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd5240316-189a-4b5d-9c3a-d5d3f8f86841', N'a@a.pl', 0, N'AMywT8FUxy+cCgPKnLsdxKrgytAOxMzoqMf66D5pszixK+++Ls4srv7aYC+5Fg4/RQ==', N'350d428b-590e-4ea2-b389-58e4b5a47876', NULL, 0, 0, NULL, 0, 0, N'Author')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea1b09b5-3167-4af9-bd9b-166c191b957e', N'm@m.pl', 0, N'ADGArJQeM4j1MZZSCoJyjKi47imd6MZAyco77dCOFyroWl8ivNhT0ZHZMQ6vtV1v7Q==', N'ba403752-f1b1-415a-9866-c5e0c0ef94e3', NULL, 0, 0, NULL, 0, 0, N'Moderator')


            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6f9f4d65-fb3c-4f39-a4c3-bfa62a37b124', N'Admin')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b518d6c9-12b3-4f8f-964d-dbd149ff4cb8', N'Author')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'12e260af-0ea0-4fd9-b836-7c47ca17ac8e', N'Moderator')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ea1b09b5-3167-4af9-bd9b-166c191b957e', N'12e260af-0ea0-4fd9-b836-7c47ca17ac8e')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a3100c7a-6ef0-43a2-9a48-96d0597677d6', N'6f9f4d65-fb3c-4f39-a4c3-bfa62a37b124')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd5240316-189a-4b5d-9c3a-d5d3f8f86841', N'b518d6c9-12b3-4f8f-964d-dbd149ff4cb8')
            
            SET IDENTITY_INSERT [dbo].[Users] ON
            INSERT INTO [dbo].[Users] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES (7, N'2020-10-29 17:00:18', NULL, 1, 1, NULL, N'd5240316-189a-4b5d-9c3a-d5d3f8f86841')
            INSERT INTO [dbo].[Users] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES (8, N'2020-10-29 17:16:27', NULL, 1, 1, NULL, N'ea1b09b5-3167-4af9-bd9b-166c191b957e')
            INSERT INTO [dbo].[Users] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES (9, N'2020-10-29 17:17:45', NULL, 1, 1, NULL, N'a3100c7a-6ef0-43a2-9a48-96d0597677d6')
            SET IDENTITY_INSERT [dbo].[Users] OFF

            ");
        }

        public override void Down()
        {
        }
    }
}
