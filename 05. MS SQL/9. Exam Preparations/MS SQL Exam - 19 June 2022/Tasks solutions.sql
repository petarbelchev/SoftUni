CREATE DATABASE [Zoo]

GO

USE [Zoo]

GO

-- 01.

CREATE TABLE [Owners] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(15) NOT NULL,
    [Address] VARCHAR(50),
)

CREATE TABLE [AnimalTypes] (
    [Id] INT PRIMARY KEY IDENTITY,
    [AnimalType] VARCHAR(30) NOT NULL
)

CREATE TABLE [Cages] (
    [Id] INT PRIMARY KEY IDENTITY,
    [AnimalTypeId] INT NOT NULL FOREIGN KEY REFERENCES [AnimalTypes]([Id])
)

CREATE TABLE [Animals] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [OwnerId] INT FOREIGN KEY REFERENCES [Owners]([Id]),
    [AnimalTypeId] INT NOT NULL FOREIGN KEY REFERENCES [AnimalTypes]([Id])
)

CREATE TABLE [AnimalsCages] (
    [CageId] INT NOT NULL FOREIGN KEY REFERENCES [Cages]([Id]),
    [AnimalId] INT NOT NULL FOREIGN KEY REFERENCES [Animals]([Id]),
    PRIMARY KEY([CageId], [AnimalId])
)

CREATE TABLE [VolunteersDepartments] (
    [Id] INT PRIMARY KEY IDENTITY,
    [DepartmentName] VARCHAR(30) NOT NULL
)

CREATE TABLE [Volunteers] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [PhoneNumber] VARCHAR(15) NOT NULL,
    [Address] VARCHAR(50),
    [AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]),
    [DepartmentId] INT NOT NULL FOREIGN KEY REFERENCES [VolunteersDepartments]([Id]),
)

-- 02.

INSERT INTO [Volunteers]
VALUES 
	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', NULL, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO [Animals]
VALUES
	('Giraffe', '2018-09-21', 21, 1),	
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', NULL, 1),
	('Tuatara', '2021-06-30', 2, 4)
	
--03.

UPDATE [Animals]
SET [OwnerId] = (
	SELECT [Id] 
	FROM [Owners] 
	WHERE [Name] = 'Kaloqn Stoqnov'
)
WHERE [OwnerId] IS NULL

-- 04.

DELETE [Volunteers]
WHERE [DepartmentId] = (
	SELECT [Id]
	FROM [VolunteersDepartments]
	WHERE [DepartmentName] = 'Education program assistant'
)

DELETE [VolunteersDepartments]
WHERE [DepartmentName] = 'Education program assistant'

-- 05.

SELECT 
	[Name],
	[PhoneNumber],
	[Address],
	[AnimalId],
	[DepartmentId]
FROM [Volunteers]
ORDER BY 
	[Name],
	[AnimalId],
	[DepartmentId]

-- 06.

SELECT 
	[a].[Name],
	[at].[AnimalType],
	FORMAT([a].[BirthDate], 'dd.MM.yyyy') AS [BirthDate]
FROM [Animals] AS [a]
JOIN [AnimalTypes] AS [at]
	ON [at].[Id] = [a].[AnimalTypeId]
ORDER BY [a].[Name]

--07.

SELECT TOP (5)
	[o].[Name] AS [Owner],
	COUNT(*) AS [CountOfAnimals]
FROM [Owners] AS [o]
JOIN [Animals] AS [a] 
	ON [a].[OwnerId] = [o].[Id]
GROUP BY [o].[Name]
ORDER BY [CountOfAnimals] DESC

-- 08.

SELECT 
	CONCAT(o.[Name], '-', [a].[Name]) AS [OwnersAnimals],
	[o].[PhoneNumber],
	[ac].[CageId]
FROM [Owners] AS [o]
JOIN [Animals] AS [a]
	ON [a].[OwnerId] = [o].[Id]
JOIN [AnimalsCages] AS [ac]
	ON [ac].[AnimalId] = [a].[Id]
WHERE [a].[AnimalTypeId] = (
	SELECT [Id]
	FROM [AnimalTypes]
	WHERE [AnimalType] = 'Mammals'
)
ORDER BY 
	[o].[Name],
	[a].[Name] DESC

-- 09.

SELECT 
	[Name],
	[PhoneNumber],
	RIGHT([Address], DATALENGTH([Address]) - CHARINDEX(',', [Address]) - 1) AS [Address]
FROM [Volunteers]
WHERE 
	[DepartmentId] = (
		SELECT [Id]
		FROM [VolunteersDepartments]
		WHERE [DepartmentName] = 'Education program assistant'
	) AND
	[Address] LIKE '%Sofia%'
ORDER BY [Name]

-- 10.

SELECT 
	[a].[Name],
	DATEPART(YEAR, [a].[BirthDate]) AS [BirthYear],
	[at].[AnimalType]
FROM [Animals] AS [a]
JOIN [AnimalTypes] AS [at]
	ON [at].[Id] = [a].[AnimalTypeId]
WHERE 
	[OwnerId] IS NULL AND
	DATEDIFF(YEAR, [BirthDate], '01/01/2022') < 5 AND
	[at].[AnimalType] != 'Birds'
ORDER BY [a].[Name]


-- 11.
GO

CREATE OR ALTER FUNCTION [udf_GetVolunteersCountFromADepartment] (@VolunteersDepartment VARCHAR(30))
RETURNS INT AS
BEGIN
	RETURN (
		SELECT COUNT(*)
		FROM [Volunteers]
		WHERE [DepartmentId] = (
			SELECT [Id]
			FROM [VolunteersDepartments]
			WHERE [DepartmentName] = @VolunteersDepartment
		)
	)
END

GO

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

-- 12.

GO

CREATE OR ALTER PROC [usp_AnimalsWithOwnersOrNot](@AnimalName VARCHAR(30)) AS
BEGIN
	DECLARE @OwnerName VARCHAR(50) = (
		SELECT [o].[Name]
		FROM [Animals] AS [a]
		JOIN [Owners] AS [o]
			ON [o].[Id] = [a].[OwnerId]
		WHERE [a].[Name] = @AnimalName
	)

	IF(@OwnerName IS NULL)
		SET @OwnerName = 'For adoption'

	SELECT
		@AnimalName AS [Name],
		@OwnerName AS [OwnersName]
END

GO

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'

EXEC usp_AnimalsWithOwnersOrNot 'Hippo'