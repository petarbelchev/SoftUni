-- Problem 7.	Create Table People
CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY,
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]
	([Name],[Height],[Weight],[Gender],[Birthdate])
VALUES
	('Petar', 1.87, 106.40, 'm', '1990-04-24'),
	('Cvetelina', 1.70, 48.5, 'f', '1989-08-17'),
	('Ivan', 1.79, 79.64, 'm', '1967-07-23'),
	('Gosho', 1.68, 67, 'm', '1984-03-03'),
	('Maria', 1.68, 52.21, 'f', '1987-05-13')