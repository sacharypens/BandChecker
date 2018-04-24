IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'bandchecker')
BEGIN
EXEC('CREATE SCHEMA bandchecker');
END

IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[bandchecker].[liedje]') AND type in (N'U'))
DROP TABLE [bandchecker].[Liedje]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[bandchecker].[Lid]') AND type in (N'U'))
DROP TABLE [bandchecker].[Lid]
GO

IF EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[bandchecker].[Band]') AND type in (N'U'))
DROP TABLE [bandchecker].[Band]
GO


CREATE TABLE [bandchecker].[Band] (
    [id] INT IDENTITY(1,1) NOT NULL,
    [naam] VARCHAR(MAX) NOT NULL,
    [omschrijving] VARCHAR(MAX),
    [Opgericht] INT,
    [genre] VARCHAR(MAX),
    PRIMARY KEY CLUSTERED ([id] ASC)
)

CREATE TABLE [bandchecker].[Lid](
    [id] INT IDENTITY(1,1) NOT NULL,
    [naam] VARCHAR(MAX) NOT NULL,
    [voornaam] VARCHAR(MAX) NOT NULL,
    [geboortedatum] date,
    [instrument] VARCHAR(MAX),
    [bandId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [bandId] FOREIGN KEY ([bandId]) REFERENCES [bandchecker].[Band]([id])
);

CREATE TABLE [bandchecker].[liedje](
    [id] INT IDENTITY(1,1) NOT NULL,
    [naam] VARCHAR(MAX) NOT NULL,
    [duurtijd] VARCHAR(MAX),
    [bandId2] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [bandId2] FOREIGN KEY ([bandId2]) REFERENCES [bandchecker].[Band]([id])
);

SET IDENTITY_INSERT [bandchecker].[Band] ON
INSERT [bandchecker].[Band]([id], [naam], [omschrijving], [opgericht], [genre])
VALUES (1, 'The Beatles', 'The Beatles was een popgroep uit de Engelse stad Liverpool. De groep was actief van 1960 tot 1970 en wordt algemeen beschouwd als de meest invloedrijke band uit de geschiedenis van de popmuziek. De bezetting bestond uit John Lennon, Paul McCartney, George Harrison en Ringo Starr; andere vroege leden waren Stuart Sutcliffe en Pete Best.', 1957, 'rock');
INSERT [bandchecker].[Band]([id], [naam], [omschrijving], [opgericht], [genre])
VALUES (2, 'The Rolling Stones', 'The Rolling Stones (vaak aangeduid als de Stones) is een Engelse rock-n-rollband die actief is sinds 1962. De band speelt, naast rock-n-roll en rock, ook stijlen als blues, country, hardrock, reggae en punk. ', 1961, 'rock');
INSERT [bandchecker].[Band]([id], [naam], [omschrijving], [opgericht], [genre])
VALUES (3, 'The Lovin Spoonful', 'The lovin Spoonful was een Amerikaanse pop-rockband met folkinvloeden, bekend van hits als "daydream" en Summer in the City".', 1957, 'rock');
INSERT [bandchecker].[Band]([id], [naam], [omschrijving], [opgericht], [genre])
VALUES (4, 'Queen', 'Queen is een Engelse rockgroep. De band is opgericht in 1970 in Londen door gitarist Brian May, zanger Freddie Mercury en drummer Roger Taylor, aangevuld met bassist John Deacon in 1971. Met tientallen hits in de jaren 70, 80 en 90, is Queen een van de succesvolste popgroepen in de geschiedenis.', 1970, 'rock');
SET IDENTITY_INSERT [bandchecker].[Band] OFF

SET IDENTITY_INSERT [bandchecker].[Lid] ON
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (1, 'Lennon', 'John', '1940-12-08', 'Gitaar, piano, zang, harmonica, orgel, percussie', 1)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (2, 'McCartney', 'Paul', '1942-06-18', 'basgitaar, gitaar, piano, zang, drum', 1)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (3, 'Harrison', 'George', '1943-02-24', 'Gitaar, Ukelele, Mondharmonica, Mandoline, Tanpuru, Basgitaar, viool', 1)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (4, 'Starr', 'Ringo', '1940-07-07', 'Drums, percussie, piano, zang, harmonica, gitaar, orgel', 1)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (5, 'Jagger', 'Mick', '1943-07-26', 'zang, mondharmonica, gitaar, piano', 2)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (6, 'Richards', 'Keith', '1943-12-18', 'gitaar, zang', 2)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (7, 'Watts', 'Charlie', '1941-06-02', 'drums', 2)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (8, 'Wood', 'Ron', '1947-06-01', 'Gitaar', 2)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (9, 'Butler', 'Joe', '1941-09-16', 'stem, autoharp, drums, percussion', 3)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (10, 'Mercury', 'Freddie', '1946-09-05', 'zang, piano', 4)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (11, 'Taylor', 'Roger', '1949-07-26', 'Drums, stem', 4)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (12, 'May', 'Brian', '1947-07-19', 'gitaar, ukulele, stem', 4)
INSERT [bandchecker].[Lid]([id], [naam], [voornaam], [geboortedatum], [instrument], [bandId])
VALUES (13, 'Deacon', 'John', '1951-08-19', 'bassgitaar, gitaar, keyboard', 4)
SET IDENTITY_INSERT [bandchecker].[Lid] OFF

SET IDENTITY_INSERT [bandchecker].[Liedje] ON
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (1, 'I want to hold your hand', '2:24', 1)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (2, 'Yesterday', '2:05', 1)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (3, 'Lucy in the Sky with Diamonds', '3:28', 1)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (4, 'Yellow Submarine', '2:38', 1)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (5, 'Let it be', '3:46', 1)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (6, 'help!', '2:18', 1)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (7, '(I cant get no) Satisfaction', '3:45', 2)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (8, 'Paint it Black', '3:45', 2)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (9, 'Angie', '4:33', 2)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (10, 'brown Sugar', '3:50', 2)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (11, 'Daydream', '2:18', 3)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (12, 'Summer in the City', '2:41', 3)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (13, 'Do you Believe in Magic?', '2:06', 3)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (14, 'Daydream', '2:18', 3)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (15, 'Did you ever have to make up your mind?', '2:00', 3)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (16, 'Bohemian Rhapsody', '5:55', 4)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (17, 'We are the Champions', '2:59', 4)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (18, 'Bohemian Rhapsody', '5:55', 4)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (19, 'dont stop me now', '3:29', 4)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (20, 'Another One Bites the Dust', '3:35', 4)
INSERT [bandchecker].[Liedje]([id], [naam], [duurtijd], [bandId2])
VALUES (21, 'Radio Ga Ga', '5:44', 4)
SET IDENTITY_INSERT [bandchecker].[Liedje] OFF