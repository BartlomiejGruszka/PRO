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
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (15, N'test', N'~/Image/220px-FIFA_20_Cover213828700.jpg', 1)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (16, N'Control_article', N'~/Image/control_article214819163.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (17, N'valhalla_article', N'~/Image/valhalla_article214830763.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (18, N'ffxvi_article', N'~/Image/final-fantasy-xvi-articlejpg214958970.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (19, N'fifa21_article', N'~/Image/fifa21_article215010978.png', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (20, N'pokemonSword-article', N'~/Image/Pokemon-Sword-and-Shield_article215022688.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (21, N'assassinscreed2_article', N'~/Image/AssassinsCreed2_article215039580.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (22, N'assassinscreed_article', N'~/Image/AssassinsCreed_article215049675.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (23, N'masseffect3_article', N'~/Image/masseffect3_article215114959.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (24, N'masseffect2_article', N'~/Image/masseffect2_article215122820.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (25, N'masseffect_article', N'~/Image/masseffect_article215131862.jpg', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (26, N'ffxivendwalker_article', N'~/Image/endwalker_article215345214.png', 2)
            INSERT INTO [dbo].[Images] ([Id], [Name], [ImagePath], [ImageTypeId]) VALUES (27, N'Parrot', N'~/Image/parrot214853179.jpg', 3)
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
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (4,'Najlepsza fabuła 2009', N'2009-01-01 17:00:00',5)
            INSERT INTO [dbo].[Awards] ([Id],[Name],[AwardDate],[GameId]) values (5,'Najlepsza fabuła 2012', N'2012-01-01 17:00:00',3)
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
            ");

            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5eb5bc6c-173f-4180-aca8-15493310fce2', N'artur@a.pl', 0, N'ABr96KZkKJmwO1/g2tYbMOhxs1sz5Biw1pyhMGUetb4qAymNk8zVAPXBRx6Ep3fjIA==', N'3635fa67-7d1b-4b35-aa54-1f7a63610f14', NULL, 0, 0, NULL, 0, 0, N'Artur')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd800af38-12ff-439a-979e-581590a99dba', N'stefan@a.pl', 0, N'APSCzQCBQayLf0Xcd16eFDPfYxVwxQSB012CYuDljqQDGouhSL62ijPenY4vEDemsw==', N'a5b66d4a-d98a-4d1c-bc71-dfae1f4990a2', NULL, 0, 0, NULL, 0, 0, N'stefan')
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Users] ON
            INSERT INTO[dbo].[Users] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES(10, N'2012-02-20 00:00:00', NULL, 1, 1, 27, N'd800af38-12ff-439a-979e-581590a99dba')
            INSERT INTO[dbo].[Users] ([Id], [RegisterDate], [Description], [IsActive], [IsPublic], [ImageId], [UserId]) VALUES(11, N'2021-01-01 00:00:00', NULL, 1, 0, NULL, N'5eb5bc6c-173f-4180-aca8-15493310fce2')
            SET IDENTITY_INSERT[dbo].[Users] OFF
            ");


            Sql(@"
            SET IDENTITY_INSERT [dbo].[UserLists] ON
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(1, N'2012-02-20 00:00:00', 'Dobre',1,9,1)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(2, N'2012-02-20 00:00:00', 'Kiepskie',1,9,2)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(3, N'2012-02-20 00:00:00', 'Kupić',1,9,3)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(4, N'2012-02-20 00:00:00', 'Gram',1,9,4)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(5, N'2012-02-20 00:00:00', 'Ukończone',1,7,1)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(6, N'2012-02-20 00:00:00', 'Porzucone',1,7,2)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(7, N'2012-02-20 00:00:00', 'Planowane',1,7,3)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(8, N'2012-02-20 00:00:00', 'Ukończone',1,10,1)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(9, N'2012-02-20 00:00:00', 'Porzucone',1,10,2)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(10, N'2012-02-20 00:00:00', 'Ukończone',1,11,1)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(11, N'2012-02-20 00:00:00', 'Porzucone',1,11,2)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(12, N'2012-02-20 00:00:00', 'Planowane',1,11,3)
            INSERT INTO[dbo].[UserLists] ([Id], [CreatedDate], [Name], [IsPublic], [UserId], [ListTypeId]) VALUES(13, N'2012-02-20 00:00:00', 'Grane',1,11,4)
            SET IDENTITY_INSERT[dbo].[UserLists] OFF
            ");


            Sql(@"
            SET IDENTITY_INSERT [dbo].[GameLists] ON
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(1, N'2012-02-20 00:00:00', 9, 8, 1, 1, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(2, N'2012-02-20 00:00:00', 15, 9, 1, 2, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(3, N'2012-02-20 00:00:00', 26, 5, 2, 10, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(4, N'2012-02-20 00:00:00', 24, 4, 4, 8, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(5, N'2012-02-20 00:00:00', 17, 6, 4, 9, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(6, N'2012-02-20 00:00:00', 12, 8, 5, 1, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(7, N'2012-02-20 00:00:00', 0, NULL, 7, 1, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(8, N'2012-02-20 00:00:00', 0, NULL, 7, 2, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(9, N'2012-02-20 00:00:00', 0, NULL, 7, 3, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(10, N'2012-02-20 00:00:00', 8, 1, 8, 7, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(11, N'2012-02-20 00:00:00', 1, 7, 9, 7, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(12, N'2012-02-20 00:00:00', 3, 10, 9, 9, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(13, N'2012-02-20 00:00:00', 6, 10, 9, 8, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(14, N'2012-02-20 00:00:00', 42, 2, 9, 11, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(15, N'2012-02-20 00:00:00', 15, 10, 9, 10, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(16, N'2012-02-20 00:00:00', 0, NULL, 11, 11, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(17, N'2012-02-20 00:00:00', 0, NULL, 11, 13, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(18, N'2012-02-20 00:00:00', 0, NULL, 11, 14, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(19, N'2012-02-20 00:00:00', 0, NULL, 11, 10, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(20, N'2012-02-20 00:00:00', 0, NULL, 11, 12, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(21, N'2012-02-20 00:00:00', 0, NULL, 11, 3, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(22, N'2012-02-20 00:00:00', 10, 9, 12, 1, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(23, N'2012-02-20 00:00:00', 20, 4, 12, 2, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(24, N'2012-02-20 00:00:00', 14, NULL, 4, 5, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(25, N'2012-02-20 00:00:00', 52, 7, 8, 1, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(26, N'2012-02-20 00:00:00', 742, 9, 8, 2, NULL)
            INSERT INTO[dbo].[GameLists] ([Id], [AddedDate], [HoursPlayed], [PersonalScore], [UserListId], [GameId], [EditedDate]) VALUES(27, N'2012-02-20 00:00:00', 111, 8, 4, 3, NULL)
            SET IDENTITY_INSERT[dbo].[GameLists] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Reviews] ON
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(1, N'Gra wciąga, jest ogromna ilość zadań które gracz może wykonać i polecam ją sprawdzić. Jak komuś nie zadziała to szybki zwrot na Steamie i powrót za pół roku po patchach. Osobiście nie myślałem, że gra CDPR mnie tak wciągnie, ale mam już za sobą kilkanaście godzin a zrobiłem może 10% fabuły. Gra jest na wiele godzin, może do końca lockdownu ją przejdę :D',N'2017-05-20 00:00:00', 4, 7, 8, NULL,7,9,1,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(2, N'Zanim może zacznę piać z zachwytu jaka to nie jest wspaniała gra, to myślę że warto wytłumaczyć dlaczego tak twierdzę. Przede wszystkim Cyberpunk, od momentu zapowiedzi w 2013, ani trochę mnie nie zainteresował. Nie śledziłem żadnych newsów na temat powstawania gry, nie oglądałem materiałów promocyjnych, ani nie oglądałem pierwszych pokazów gameplay. Grę kupiłem spontanicznie około dwa tygodnie przed premierę, nastawiając się na nią bardzo neutralnie, śmiejąc się przy tym z wyolbrzymionych oczekiwań i hype na temat tej gry. Przechodząc jednak do recenzji...', N'2017-02-20 00:00:00', 6, 7, 6, NULL,5,9,2,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(3,  N'Po 18 godzinach i kilku hotfixach muszę przyznać, że gra naprawdę jest coraz mniej zbugowana. Co do fabuły nie można się doczepić - wciąga i wzbudza emocje. Detale w tej grze stoją na najwyższym poziomie, przez co często zamiast skupić się na głównych questach, wolę czasami pochodzić po mieście i porobić coś bardziej oderwanego od ciągu fabuły. Genialna gra, słów brak by opisać wrażenia po tych kilkunastu godzinach gry. Kto się waha - niech się przemoże i kupi tę grę. To najlepiej wydane 200 zł na grę w moim życiu.',N'2017-03-10 00:00:00', 7, 7, 7, NULL,7,9,3,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(4,  N'Najprawdopodobniej jedna z najlepszych gier jakie powstały. Idealnie pokazuje brudny cyberpunkowy świat przez co wczucie się w cały ten klimat przychodzi z łatwością. Gra ma swoje problemy (liczne bugi, niektóre bardziej upierdliwe, drugie mniej) ale fabularnie - jest miazga. Mimo wszystko, warto poczekać na łatki które naprawią zdecydowaną większość bugów, ale nie zmienia to faktu że dostaliśmy coś, na co warto było czekać.',N'2012-09-20 00:00:00', 9, 9, 5, NULL,8,9,5,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(5, N'Myślę że po 85 godzinach spędzonych w Night City, mogę wreszcie opisać jak czuję się z nowym tworem CD Projekt Red zwanym Cyberpunk 2077 bazowanym na papierowej grze fabularnej Cyberpunk 2020 stworzonej przez Mikea Pondsmitha. Po ośmiu latach w końcu doczekaliśmy się premiery gry na którą czekała bardzo dużą część graczy.',N'2012-05-20 00:00:00',  10, 10, 9, NULL,9,9,9,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(6,  N'Na początku myślałem ,że to żart jak gra jest zabugowana no i jak działa ale... no i właśnie jest to ale po przestawieniu myślenia i wgłębieniu się w fabułę ciężko było mi oderwać się od fabuły zarówno głównej jak i pobocznej. Jedna z lepiej napisanych historii. Czy gra mogłaby być lepiej zoptymalizowana - jasne, czy powinno być mnie bugów i glitch - jasne.',N'2012-01-20 00:00:00', 7, 5, 4, NULL,5,10,1,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(7,  N'Cyberpunk 2077. Jeżeli o mnie chodzi nie czułem jakiegoś mocnego hajpu na tę grę, nie czekałem na nią jakoś mocno, nawet nie planowałem jej kupić, a tym bardziej na premierę, bo nie jestem zwolennikiem kupowania gier zaraz po ich wyjściu, nie zapoznając się wcześniej z opiniami i recenzjami danej gry, jedyne co przyciągało moją uwagę to mocna kampania marketingowa i to że jest to gra polskiego studia CD projekt',N'2015-05-25 00:00:00', 6, 6, 3, N'2012-02-21 00:00:00',2,10,2,8)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(8,  N'Gra stawia nowe filary w gamedevie, jeśli chodzi o wertykalną warstwę fabularną, czy też oprawę audiowizualną. Ogrywanie jej na RayTracingu to istne wzrokowe wodotryski, ale nie każdy portfel jest na tyle gruby, żeby ograć to w stabilnych 60 klatkach. Natomiast gra ma potężne wady, których nie jestem w stanie wybaczyć developerom.',N'2012-06-01 00:00:00', 1, 2, 1, N'2012-02-21 00:00:00',2,10,3,8)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(9,  N'Sądzę, że po przegraniu 160h+ mogę w końcu się wypowiedzieć. Gra ma błędy. Ale nie są to błędy niszczące rozrywkę, w najgorszym przypadku wystarczy wgrać save i po sprawie. tym bardziej, że sejwy wgrywają się w parenaście-paredziesiąt sekund. Pod względem otwartego świata nie to parę rzeczy kuleje',N'2018-12-20 00:00:00', 6, 8, 7, NULL,7,10,11,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(10,  N'Zdecydowanie polecam ale nie będę kłamać że gra na obecną chwile jest idealna, zarzuty w kwestii większych lub mniejszych błędów są jak najbardziej prawdziwe, ale to wciąż dobrze wykreowany i zbudowany świat z dobrą historią i świetnymi postaciami. Moja ocena 7/10. Przyszłe patche naprawią grę i będzie 10/10 :)',N'2012-11-20 00:00:00', 9, 7, 9, NULL,7,10,12,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(11,  N'Dla tych co się zastanawiają nad kupnem gry na szybko..., jeśli nie przeszkadzają Ci wizualne błędy, a Twój komputer daje przysłowiowo radę, to bierz i nie zastanawiaj się. Ja osobiście w trakcie 50h gry nie uświadczyłem żadnego crasha, poważnych błędów lub zbugowanych questów. A nawet jeśli by się zdarzyło to dla mnie żaden problem dopóki nie jest to częste.',N'2019-10-20 00:00:00', 5, 5, 4, N'2012-02-21 00:00:00',7,11,1,8)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(12,  N'Są drobne bugi w grze, najczęściej zdarzało mi się, że nie mogłem podnosić różnych itemów. Postacie jak i auta kawałek się teleportują. Animacje postaci ludzią przeskakiwać tzn. jedna po drugiej nie są płynne.',N'2020-02-20 00:00:00', 7, 2, 3, NULL,5,11,2,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(13,  N'Obcowanie z tą grą to sinusoida oceny. Od początkowego zachwytu (grafiką i klimatem), przez rozczarowanie (odkrywanie elementów, które są strasznie słabe), realizm (wady nie przesłaniają zalet), aż po zakochanie (zżycie z postaciami i siła emocji przesłaniają biedę innych elementów)',N'2014-02-20 00:00:00', 5, 7, 6, N'2012-02-21 00:00:00',4,11,5,8)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(14,  'Zdecydowanie się nie zawiodłem, klimaty i oprawa gry jest dokładnie taka jak sobie wyobrażałem. Rozgrywka bardzo przyjemna zdecydowanie nie będziecie się nudzić na mapie jest mnóstwo aktywności. Mapa jest świetnie zrobiona Night City wygląda ja faktyczna cyberpunkowa metropolia. Niestety na tą chwilę ma duże problemy z optymalizacją i jest sporo błędów ale wierzę że za jakiś czas twórcy to naprawią. Gra zdecydowanie warta polecenia.',N'2018-02-20 00:00:00', 8, 7, 7, NULL,8,11,7,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(15,  'Mimo kilku małych problemów nie przeszkodziło mi to z cieszenia się z gry. Przez 6 godzin grania musiałem wczytać checkpoint tylko raz przez jednego buga. Nowe patche mogą pomóc z optymalizacją więc polecam na nie czekać ( Patch 1.04 właśnie wiele problemów z optymalizacją naprawił )',N'2016-03-20 00:00:00', 5, 7, 6, NULL,10,7,1,NULL)
            INSERT INTO[dbo].[Reviews] ([Id],[Content], [ReviewDate], [GraphicsScore], [StoryScore], [MusicScore], [EditDate],[GameplayScore],[UserId],[GameId],[ModeratorId]) VALUES(16,  'Uwaga uwaga, gra ma bugi, kto by się spodziewał. Dobra to teraz o grze. Jest spoko, krótka, ale sporo zadań pobocznych. customizacja jest dość słaba, ale dobieranie zdolności i ogólnie aspekty RPG typu drzewka, statystyki broni itp są bardzo mocne. Grafika jest dobra, nawet na średnio niskich ustawieniach. Na pierwszym patchu w czasie jednej z misji pod koniec drugiego aktu gra się wysypywała, ale teraz nie ma większych problemów. Fabuła jest okej',N'2012-02-20 00:00:00', 7, 8, 7, NULL,8,8,1,NULL)
            SET IDENTITY_INSERT[dbo].[Reviews] OFF
            ");

            Sql(@"
            SET IDENTITY_INSERT [dbo].[Articles] ON
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(1,N'Tytuł artykułu', N'2019-06-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 25, 1, 7, 1,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(2,N'Tytuł artykułu', N'2020-12-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 24, 2, 7, 1,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(3,N'Tytuł artykułu', N'2020-02-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 23, 3, 7, 1,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(4,N'Tytuł artykułu', N'2019-11-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 22, 4, 7, 1,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(5,N'Tytuł artykułu', N'2018-10-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 21, 5, 7, 1,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(6,N'Tytuł artykułu', N'2019-07-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 20, 6, 7, 2,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(7,N'Tytuł artykułu', N'2017-03-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 19, 8, 9, 2,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(8,N'Tytuł artykułu', N'2017-01-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 26, 10, 9, 2,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(9,N'Tytuł artykułu', N'2020-04-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 18, 11, 9, 2,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(10,N'Tytuł artykułu', N'2020-05-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 17, 12, 9, 3,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            INSERT INTO[dbo].[Articles] ([Id], [Title],[PublishedDate], [SourceLink], [Content], [ImageId], [GameId], [UserId],[ArticleTypeId],[IsActive],[Preview]) 
                VALUES(11,N'Tytuł artykułu', N'2020-08-20 00:00:00','link',N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.', 16, 13, 9, 3,1,N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.')
            SET IDENTITY_INSERT[dbo].[Articles] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
