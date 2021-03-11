namespace PRO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SampleData : DbMigration
    {
        public override void Up()
        {

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Status] ON
            INSERT INTO [dbo].[Status] ([Id],[Name]) values (1,'Zapowiedziana')
            INSERT INTO [dbo].[Status] ([Id],[Name]) values (2,'Wczesny dostęp')
            INSERT INTO [dbo].[Status] ([Id],[Name]) values (3,'Alfa')
            INSERT INTO [dbo].[Status] ([Id],[Name]) values (4,'Beta')
            INSERT INTO [dbo].[Status] ([Id],[Name]) values (5,'Dostępna')
            INSERT INTO [dbo].[Status] ([Id],[Name]) values (6,'Anulowana')
            INSERT INTO [dbo].[Status] ([Id],[Name]) values (7,'Niedostępna')
            SET IDENTITY_INSERT [dbo].[Status] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Series] ON
            INSERT INTO [dbo].[Series] ([Id],[Name]) values (1,'FIFA')
            INSERT INTO [dbo].[Series] ([Id],[Name]) values (2,'Pokemon')
            INSERT INTO [dbo].[Series] ([Id],[Name]) values (3,'Mass Effect')
            INSERT INTO [dbo].[Series] ([Id],[Name]) values (4,'Assassins Creed')
            INSERT INTO [dbo].[Series] ([Id],[Name]) values (5,'Civilization')
            INSERT INTO [dbo].[Series] ([Id],[Name]) values (6,'Call of Duty')
            INSERT INTO [dbo].[Series] ([Id],[Name]) values (7,'Final Fantasy')
            SET IDENTITY_INSERT [dbo].[Series] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Tags] ON
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (1,'Pierwszoosobowa')
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (2,'Trzecioosobowa')
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (3,'Fabularna')
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (4,'Otwarty świat')
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (5,'Science-Fiction')
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (6,'Historyczna')
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (7,'Zespołowa')
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (8,'Jeden gracz')
            INSERT INTO [dbo].[Tags] ([Id],[Name]) values (9,'Wielu graczy')
            SET IDENTITY_INSERT [dbo].[Tags] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[ListTypes] ON
            INSERT INTO [dbo].[ListTypes] ([Id],[Name]) values (1,'Ukończone')
            INSERT INTO [dbo].[ListTypes] ([Id],[Name]) values (2,'Porzucone')
            INSERT INTO [dbo].[ListTypes] ([Id],[Name]) values (3,'Planowane')
            INSERT INTO [dbo].[ListTypes] ([Id],[Name]) values (4,'Obecnie grane')
            SET IDENTITY_INSERT [dbo].[ListTypes] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[ArticleTypes] ON
            INSERT INTO [dbo].[ArticleTypes] ([Id],[Name]) values (1,'Zapowiedź')
            INSERT INTO [dbo].[ArticleTypes] ([Id],[Name]) values (2,'Recenzja')
            INSERT INTO [dbo].[ArticleTypes] ([Id],[Name]) values (3,'Felieton')
            INSERT INTO [dbo].[ArticleTypes] ([Id],[Name]) values (4,'Plotka')
            INSERT INTO [dbo].[ArticleTypes] ([Id],[Name]) values (5,'Aktualizacja')
            SET IDENTITY_INSERT [dbo].[ArticleTypes] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Genres] ON
            INSERT INTO [dbo].[Genres] ([Id],[Name]) values (1,'RPG')
            INSERT INTO [dbo].[Genres] ([Id],[Name]) values (2,'FPS')
            INSERT INTO [dbo].[Genres] ([Id],[Name]) values (3,'RTS')
            INSERT INTO [dbo].[Genres] ([Id],[Name]) values (4,'Sportowa')
            INSERT INTO [dbo].[Genres] ([Id],[Name]) values (5,'Strategiczna')
            INSERT INTO [dbo].[Genres] ([Id],[Name]) values (6,'Akcji')
            SET IDENTITY_INSERT [dbo].[Genres] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Languages] ON
            INSERT INTO [dbo].[Languages] ([Id],[Name]) values (1,'Angielski')
            INSERT INTO [dbo].[Languages] ([Id],[Name]) values (2,'Niemiecki')
            INSERT INTO [dbo].[Languages] ([Id],[Name]) values (3,'Francuski')
            INSERT INTO [dbo].[Languages] ([Id],[Name]) values (4,'Japoński')
            INSERT INTO [dbo].[Languages] ([Id],[Name]) values (5,'Hiszpański')
            INSERT INTO [dbo].[Languages] ([Id],[Name]) values (6,'Rosyjski')
            INSERT INTO [dbo].[Languages] ([Id],[Name]) values (7,'Polski')
            INSERT INTO [dbo].[Languages] ([Id],[Name]) values (8,'Chiński')
            SET IDENTITY_INSERT [dbo].[Languages] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Companies] ON
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (1,'Electronic Arts', N'1982-05-27 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (2,'Bioware', N'1995-02-01 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (3,'Ubisoft', N'1986-03-12 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (4,'Ubisoft Montreal', N'1997-04-25 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (5,'Nintendo', N'1889-09-23 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (6,'Gamefreak', N'1989-04-26 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (7,'Activision', N'1979-10-01 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (8,'Blizzard', N'1991-02-08 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (9,'Treyarch', N'1996-01-01 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (10,'Infinity Ward', N'2002-05-01 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (11,'CD Projekt Red', N'1994-01-01 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (12,'Firaxis Games', N'1996-05-01 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (13,'Take-Two Interactive', N'1993-09-30 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (14,'Microsoft', N'1975-04-04 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (15,'Sony', N'1946-05-07 17:00:00',1)
            INSERT INTO [dbo].[Companies] ([Id],[Name],[CreatedDate],[IsActive]) values (16,'Square Enix', N'1955-05-07 17:00:00',1)
            SET IDENTITY_INSERT [dbo].[Companies] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Platforms] ON
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (1,'Xbox 360',N'1994-01-01 17:00:00',1,14)
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (2,'Xbox One',N'1994-01-01 17:00:00',1,14)
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (3,'Xbox Series X',N'1994-01-01 17:00:00',1,14)
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (4,'Switch',N'1994-01-01 17:00:00',1,5)
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (5,'3DS',N'1994-01-01 17:00:00',1,5)
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (6,'Playstation 3',N'1994-01-01 17:00:00',1,15)
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (7,'Playstation 4',N'1994-01-01 17:00:00',1,15)
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (8,'Playstation 5',N'1994-01-01 17:00:00',1,15)
            INSERT INTO [dbo].[Platforms] ([Id],[Name], [ReleaseDate], [IsActive], [CompanyId]) values (9,'PC ',N'1994-01-01 17:00:00',1,14)
            SET IDENTITY_INSERT [dbo].[Platforms] OFF
            ");

            Sql(@"SET IDENTITY_INSERT [dbo].[ImageTypes] ON
            INSERT INTO[dbo].[ImageTypes]([Id], [Name]) VALUES(1, N'Gra')
            INSERT INTO[dbo].[ImageTypes] ([Id], [Name]) VALUES(2, N'Artykuł')
            INSERT INTO[dbo].[ImageTypes] ([Id], [Name]) VALUES(3, N'Użytkownik')
            SET IDENTITY_INSERT[dbo].[ImageTypes] OFF");

            Sql(@"SET IDENTITY_INSERT [dbo].[Images] ON
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (1, N'FIFA 20', N'~/Image/220px-FIFA_20_Cover214806118.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (2, N'FIFA 21', N'~/Image/220px-FIFA_21_Cover214815562.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (3, N'Assassins Creed 1', N'~/Image/220px-Assassin''s_Creed214827007.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (4, N'Little Nightmares II', N'~/Image/6034312b4499a2d8ae681e7ad74b5500-98214840748.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (5, N'Cyberpunk 2077', N'~/Image/b05b3823508c28c8f8646e8bcc605b3e-98214849203.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (6, N'Pokemon Sword', N'~/Image/Sword_EN_boxart214902510.png',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (7, N'Assassins Creed 2', N'~/Image/assassinscreed2214915719.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (8, N'Assassins Creed Valhalla', N'~/Image/Assassins-creed-valhalla-jaquette214926466.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (9, N'Mass Effect', N'~/Image/MassEffect214954176.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (10, N'Mass Effect 2', N'~/Image/MassEffect2215000597.png',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (11, N'Mass Effect 3', N'~/Image/Mass_Effect_3_Game_Cover215010594.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (12, N'FFXIV Endwalker', N'~/Image/FFXIV_Endwalker_Amano_art215025516.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (13, N'FFXVI', N'~/Image/Final_Fantasy_XVI_Key_Art215032567.png',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (14, N'Control', N'~/Image/305a13f648147e862ed5e86d83d51dd6-98215049818.jpg',1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (32, N'test', N'~/Image/220px-FIFA_20_Cover213828700.jpg', 1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (33, N'Control_article', N'~/Image/control_article214819163.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (34, N'valhalla_article', N'~/Image/valhalla_article214830763.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (35, N'ffxvi_article', N'~/Image/final-fantasy-xvi-articlejpg214958970.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (36, N'fifa21_article', N'~/Image/fifa21_article215010978.png', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (37, N'pokemonSword-article', N'~/Image/Pokemon-Sword-and-Shield_article215022688.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (38, N'assassinscreed2_article', N'~/Image/AssassinsCreed2_article215039580.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (39, N'assassinscreed_article', N'~/Image/AssassinsCreed_article215049675.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (40, N'masseffect3_article', N'~/Image/masseffect3_article215114959.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (41, N'masseffect2_article', N'~/Image/masseffect2_article215122820.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (42, N'masseffect_article', N'~/Image/masseffect_article215131862.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (43, N'ffxivendwalker_article', N'~/Image/endwalker_article215345214.png', 2)
            SET IDENTITY_INSERT [dbo].[Images] OFF
");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Games] ON
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (1,'Mass Effect',
                    N'Komputerowa fabularna gra akcji stworzona przez studio BioWare, wydana pierwotnie w 2007 roku przez Microsoft Game Studios na konsolę Xbox 360,
                    będąca pierwszą częścią serii Mass Effect. Jej akcja rozgrywa się w XXII wieku, kiedy Drodze Mlecznej grozi zagłada ze strony superzaawansowanej
                    rasy maszyn znanych jako Żniwiarze. Gracz wciela się w komandora Sheparda, elitarnego żołnierza próbującego powstrzymać inwazję. Rozgrywka składa
                    się z kilku głównych elementów: wykonywania zadań, walki, eksplorowania kosmosu i interakcji z bohaterami niezależnymi.',
                    N'2007-01-01 17:00:00', 1, 9, 5, 1, 3, 1, 2, 9)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (2,'Mass Effect 2',
                    N'Fabularna gra akcji stworzona przez BioWare, wydana przez Electronic Arts w styczniu 2010 roku na platformy Microsoft Windows i Xbox 360, 
                    a rok później na konsolę PlayStation 3. Stanowi drugą część trylogii Mass Effect. Akcja rozgrywa się w XXII wieku w Drodze Mlecznej, gdzie ludzkości zagraża 
                    insektoidalna rasa Obcych znanych jako Zbieracze. Gracz wciela się w postać komandora Sheparda, elitarnego żołnierza sił ziemskich, który w celu pokonania 
                    zagrożenia musi skompletować oddział gotowy wziąć udział w misji samobójczej. Wczytując zapis z pierwszej części gracz może kształtować fabułę Mass Effect 2 
                    na wiele sposobów.',
                    N'2010-01-26 17:00:00', 1, 9, 5, 1, 3, 1, 2, 10)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (3,'Mass Effect 3',
                    N'Fabularna gra akcji, trzecia część serii Mass Effect, stworzona przez studio BioWare, wydana przez Electronic Arts równocześnie na platformach Microsoft Windows,
                    Xbox 360 (z obsługą Kinecta) i PlayStation 3. Ogłoszona została 11 grudnia 2010 roku, a wersja demonstracyjna została udostępniona 14 lutego 2012 roku. 
                    Premiera gry nastąpiła 6 marca 2012 roku w Ameryce Północnej i 9 marca 2012 roku w Europie. W Polsce i Australii ukazała się 8 marca 2012 roku, a w Japonii 15 marca 2012 roku.
                    Mass Effect 3 w przeciwieństwie do poprzednich części nie został wydany w pełnej polskiej wersji językowej z dubbingiem, a jedynie z polskimi napisami.',
                     N'2012-03-06 17:00:00', 1, 9, 5, 1, 3, 1, 2, 11)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (4,'Assassins Creed',
                    N'Przygodowa gra akcji stworzona przez studio Ubisoft Montreal i wydana w listopadzie 2007 roku na konsole PlayStation 3, Xbox 360 oraz w kwietniu 2008 roku
                     na platformę Microsoft Windows. Akcja tytułu toczy się naprzemiennie w dwóch okresach czasowych: podczas III wyprawy krzyżowej, w roku 1191 oraz na początku
                    września 2012 roku. Gracz wciela się w członka bractwa asasynów znanego jako Altaïr ibn La-Ahad, którego celem jest wyeliminowanie dziewięciu postaci propagujących wyprawy krzyżowe
                    i odpowiedzialnych za cierpienia wielu ludzi. Gracz odwiedza pięć historycznych miejsc: Jerozolimę, Damaszek, Akkę, Masjaf oraz Arsuf.',
                     N'2007-11-06 17:00:00', 1, 1, 5, 6, 4, 3, 4, 3)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (5,'Assassins Creed II',
                    N'Głównym bohaterem gry jest Ezio Auditore da Firenze, młody szlachcic z bogatej florenckiej rodziny. Podobnie jak Altaïr ibn La-Ahad z pierwszej części gry,
                    jest on praprzodkiem Desmonda Milesa, asasyna przetrzymywanego przez korporację Abstergo Industries[25]. Fabuła rozpoczyna się we współczesności, kiedy Desmond i Lucy Stillman uciekają
                    z Abstergo do kryjówki, gdzie spotykają się z innymi współczesnymi asasynami, Shaunem i Rebeką. W kryjówce Desmond korzysta z ulepszonej wersji animusa i przeżywa wspomnienia swojego przodka,
                    aby przez Efekt Krwi nauczyć się być asasynem.',
                     N'2009-11-17 17:00:00', 1, 1, 5, 6, 4, 3, 4, 7)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (6,'Pokemon Sword',
                    N'Pokémon Sword i Pokémon Shield to gry RPG z 2019 roku opracowane przez Game Freak i opublikowane przez The Pokémon Company i Nintendo na Nintendo Switch. 
                    Są to pierwsze odsłony ósmej generacji serii gier wideo Pokémon i drugie z serii, po Pokémon: Lets Go, Pikachu!',
                     N'2019-11-15 17:00:00', 1, 4, 1, 1, 2, 5, 6, 6)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (7,'FIFA 20',
                    N'FIFA 20 jest komputerową grą sportową o tematyce piłki nożnej. Po raz czwarty w serii FIFA zastosowano silnik gry Frostbite. W grze pojawił się nowy tryb o nazwie „Volta”.
                    Zmiany w mechanizmie rozgrywki zostały zaprezentowane 18 lipca 2019 roku. Wśród zmian względem poprzedniczki, gra posiada przebudowany system stałych fragmentów gry. 
                    Najważniejszą zmianą jest dodanie do mechanizmu wykonywania rzutów karnych i rzutów rożnych nowatorskiego systemu celowania i kontroli piłki, która według zapowiedzi twórców została zwiększona.',
                     N'2019-11-17 17:00:00', 1, 9, 2, 4, 1, 1, 1, 1)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (8,'FIFA 21',
                    N'FIFA 21 to gra wideo symulująca piłkę nożną wydana przez Electronic Arts w ramach serii FIFA. Jest to 28. odsłona serii FIFA i zostanie wydana 9 października 2021
                    roku na platformę Microsoft Windows, Nintendo Switch, PlayStation 4 i Xbox One.',
                     N'2021-10-09 17:00:00', 1, 7, 1, 4, 1, 1, 1, 2)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (9,'Cyberpunk 2077',
                    N'Komputerowa fabularna gra akcji stworzona przez studio CD Projekt Red.  Stanowi adaptację papierowej gry fabularnej Cyberpunk 2020 i jest osadzona 57 lat później w 
                    otwartym świecie dystopijnego Night City. Akcja gry rozgrywa się w świecie przedstawionym z perspektywy pierwszej osoby. Główny bohater Cyberpunka, najemnik o imieniu V,
                    wykonuje zadania, korzystając z umiejętności hakowania i obsługi maszyn, jak również z różnych rodzajów broni.',
                     N'2022-11-17 17:00:00', 1, 1, 6, 6, NULL, 11, 11, 5)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (10,'Final Fantasy XIV: Endwalker',
                    N'Final Fantasy XIV Endwalker trafi do nas jesienią 2021 roku i zakończy wątek fabularny rozwijany od 2013 roku. Jednocześnie będzie to początek zupełnie nowej historii. Od samych twórców dowiedzieliśmy się, 
                    że w trakcie przygody trafimy między innymi na księżyc, do stolicy imperium Garlemald oraz do miasta Radz-at-Han.',
                     N'2021-11-17 17:00:00', 1, 7, 1, 1, 7, 16, 16, 12)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (11,'Final Fantasy XVI',
                    N'Final Fantasy XVI to nadchodząca gra RPG akcji opracowana i wydana przez Square Enix na PlayStation 5. Jest to szesnasty tytuł z głównej serii Final Fantasy. 
                    Grę produkuje Naoki Yoshida, a reżyseruje ją Hiroshi Takai.',
                     NULL, 1, 7, 1, 1, 7, 16, 16, 13)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (12,'Assassins Creed Valhalla',
                    N'Przygodowa gra akcji wyprodukowana przez kanadyjskie studio Ubisoft Montréal, stanowiąca dwunastą główną odsłonę serii Assassin’s Creed i kontynuację Assassin’s Creed Odyssey.
                    Akcja gry dzieje się w IX wieku w średniowiecznej Anglii.',
                     N'2021-12-17 17:00:00', 1, 3, 1, 6, 4, 3, 4, 8)
            INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (
                    13,'Control',
                    N'Control to trzecioosobowa strzelanka science fiction. Gracz musi zmierzyć się z inwazją sił nie z tego świata, a w walce z nimi wykorzystuje szereg zdolności specjalnych oraz telekinetyczny pistolet, 
                    który poza strzelaniem pozwala ciskać obiektami i przeciwnikami na odległość.',
                    N'2021-10-17 17:00:00', 1, 4, 4, 5, NULL, 6, 7, 14)
             INSERT INTO [dbo].[Games] ([Id],[Title],[Description], [ReleaseDate], [IsActive], [PlatformId], [StatusId], [GenreId], [SeriesId], [PublisherId], [DeveloperId], [ImageId])
                values (14,'Little Nightmares 2',
                    N'Little Nightmares II to przygodowa gra logiczno-platformowa z gatunku horroru.',
                     NULL, 1, 4, 1, 3, NULL, 8, 8, 4)
            SET IDENTITY_INSERT [dbo].[Games] OFF
            ");

        }

        public override void Down()
        {
        }
    }
}
