-- Problem 13.	Movies Database
CREATE DATABASE [Movies]

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(250)
)

CREATE TABLE [Genres] (
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(250)
)

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(250)
)

CREATE TABLE [Movies] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL UNIQUE,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] SMALLINT NOT NULL,
	[Length] SMALLINT NOT NULL,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] DECIMAL(2,1) NOT NULL,
	[Notes] NVARCHAR(250)
)

INSERT INTO [Genres]
	([GenreName])
VALUES
	('Action'),
	('Adventure'),
	('Comedy'),
	('Fantasy'),
	('Horror')

INSERT INTO [Categories]
	([CategoryName])
VALUES
	('Kids'),
	('Teenagers'),
	('Young Adults'),
	('Adults'),
	('Old ages')

INSERT INTO [Directors]
	([DirectorName])
VALUES
	('Alfred Hitchcock'),
	('D.W. Griffith'),
	('Orson Welles'),
	('Jean-Luc Godard'),
	('Charlie Chaplin')

INSERT INTO [Movies]
	([Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId],[Rating])
VALUES
	('A Countess from Hong Kong', 5, 1967, 120, 3, 3, 6.0),
	('Citizen Kane', 3, 1941, 119, 5, 4, 8.3),
	('Family Plot', 1, 1976, 120, 3, 2, 6.8),
	('Footlight Varieties', 2, 1951, 61, 1, 4, 5.0),
	('Pierrot le fou', 4, 1965, 102, 1, 5, 7.9)