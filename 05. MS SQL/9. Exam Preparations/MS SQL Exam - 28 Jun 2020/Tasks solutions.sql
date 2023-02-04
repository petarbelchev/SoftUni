CREATE DATABASE [ColonialJourney]

USE [ColonialJourney]

-- 01.DDL
 
CREATE TABLE [Planets] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [Spaceports] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [PlanetId] INT NOT NULL FOREIGN KEY REFERENCES [Planets]([Id])
)

CREATE TABLE [Spaceships] (
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    [Manufacturer] VARCHAR(30) NOT NULL,
    [LightSpeedRate] INT DEFAULT 0
)

CREATE TABLE [Colonists] (
    [Id] INT PRIMARY KEY IDENTITY,
    [FirstName] VARCHAR(20) NOT NULL,
    [LastName] VARCHAR(20) NOT NULL,
    [Ucn] VARCHAR(10) NOT NULL UNIQUE,
    [BirthDate] DATE NOT NULL
)

CREATE TABLE [Journeys] (
    [Id] INT PRIMARY KEY IDENTITY,
    [JourneyStart] DATETIME NOT NULL,
    [JourneyEnd] DATETIME NOT NULL,
    [Purpose] VARCHAR(11),
    [DestinationSpaceportId] INT NOT NULL FOREIGN KEY REFERENCES [Spaceports]([Id]),
    [SpaceshipId] INT NOT NULL FOREIGN KEY REFERENCES [Spaceships]([Id]),
    CONSTRAINT [CHK_Purpose] CHECK (
        [Purpose] = 'Medical' OR 
        [Purpose] = 'Technical' OR 
        [Purpose] = 'Educational' OR 
        [Purpose] = 'Military'
    )
)

CREATE TABLE [TravelCards] (
    [Id] INT PRIMARY KEY IDENTITY,
    [CardNumber] VARCHAR(10) NOT NULL UNIQUE,
    [JobDuringJourney] VARCHAR(8),
    [ColonistId] INT NOT NULL FOREIGN KEY REFERENCES [Colonists]([Id]),
    [JourneyId] INT NOT NULL FOREIGN KEY REFERENCES [Journeys]([Id]),
    CONSTRAINT [CHK_JobDuringJourney] CHECK (
        [JobDuringJourney] = 'Pilot' OR 
        [JobDuringJourney] = 'Engineer' OR 
        [JobDuringJourney] = 'Trooper' OR 
        [JobDuringJourney] = 'Cleaner' OR
        [JobDuringJourney] = 'Cook'
    )
)

--02.Insert

INSERT INTO [Planets]
VALUES ('Mars'), ('Earth'), ('Jupiter'), ('Saturn')

INSERT INTO [Spaceships]
VALUES
    ('Golf', 'VW', 3),
    ('WakaWaka', 'Wakanda', 4),
    ('Falcon9', 'SpaceX', 1),
    ('Bed', 'Vidolov', 6)

-- 03. Update

UPDATE [Spaceships]
SET [LightSpeedRate] += 1
WHERE [Id] BETWEEN 8 AND 12

-- 04. Delete

DELETE [TravelCards]
WHERE [JourneyId] IN (SELECT TOP 3 [Id] FROM [Journeys])

DELETE [Journeys]
WHERE [Id] IN (SELECT TOP 3 [Id] FROM [Journeys])

-- 05. 

SELECT 
    [Id],
    FORMAT([j].[JourneyStart], 'dd/MM/yyyy') AS [JourneyStart],
    FORMAT([j].[JourneyEnd], 'dd/MM/yyyy') AS [JourneyEnd]
FROM [Journeys] AS [j]
WHERE [Purpose] = 'Military'
ORDER BY [j].[JourneyStart]

-- 06.

SELECT 
    [c].[Id],
    CONCAT_WS(' ', [c].[FirstName], [c].[LastName]) AS [full_name]
FROM [Colonists] AS [c]
LEFT JOIN [TravelCards] AS [t] ON [t].[ColonistId] = [c].[Id]
WHERE [t].[JobDuringJourney] = 'Pilot'
ORDER BY [c].[Id]

-- 07.

SELECT COUNT(*) AS [count]
FROM [TravelCards] AS [t]
LEFT JOIN [Journeys] AS [j] ON [j].[Id] = [t].[JourneyId]
WHERE [j].[Purpose] = 'Technical'

-- 08.

SELECT
	[s].[Name],
	[s].[Manufacturer]
FROM [TravelCards] AS [t]
JOIN [Colonists] AS [c] ON [c].[Id] = [t].[ColonistId]
JOIN [Journeys] AS [j] ON [j].[Id] = [t].[JourneyId]
JOIN [Spaceships] AS [s] ON [s].[Id] = [j].[SpaceshipId]
WHERE 
	DATEDIFF(YEAR, [c].[BirthDate], '01-01-2019') < 30 AND 
	[t].[JobDuringJourney] = 'Pilot'
ORDER BY [s].[Name]

-- 09.

SELECT
	[p].[Name] AS [PlanetName],
	COUNT(*) AS [JourneysCount]
FROM [Journeys] AS [j]
JOIN [Spaceports] AS [s] ON [s].[Id] = [j].[DestinationSpaceportId]
JOIN [Planets] AS [p] ON [p].[Id] = [s].[PlanetId]
GROUP BY [p].[Name]
ORDER BY [JourneysCount] DESC, [PlanetName]

-- 10.

SELECT *
FROM (
	SELECT 
		[t].[JobDuringJourney],
		CONCAT([c].[FirstName],' ', [c].[LastName]) AS [FullName],
		RANK() OVER (PARTITION BY [t].[JobDuringJourney] ORDER BY [c].[BirthDate]) AS [JobRank]
	FROM [TravelCards] as [t]
	JOIN [Colonists] AS [c] ON [c].[Id] = [t].[ColonistId]
) AS [dt]
WHERE [dt].[JobRank] = 2

-- 11.

GO
CREATE OR ALTER FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR(30)) 
RETURNS INT AS
BEGIN
	RETURN (
		SELECT COUNT(*)
		FROM (
			SELECT [t].[ColonistId]
			FROM [Planets] AS [p]
			JOIN [Spaceports] AS [s] ON [s].[PlanetId] = [p].[Id]
			JOIN [Journeys] AS [j] ON [j].[DestinationSpaceportId] = [s].[Id]
			JOIN [TravelCards] AS [t] ON [t].[JourneyId] = [j].[Id]
			GROUP BY [t].[ColonistId], [p].[Name]
			HAVING [p].[Name] = @PlanetName
		) AS [dt]
	)
END
GO

SELECT dbo.udf_GetColonistsCount('Otroyphus')

-- 12.

GO
CREATE OR ALTER PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN
	IF(@JourneyId NOT IN (SELECT [Id] FROM [Journeys]))
		THROW 50001, 'The journey does not exist!', 1
	
	IF(@NewPurpose = (SELECT [Purpose] FROM [Journeys] WHERE [Id] = @JourneyId))
		THROW 50002, 'You cannot change the purpose!', 1
	
	UPDATE [Journeys]
	SET [Purpose] = @NewPurpose
	WHERE [Id] = @JourneyId
END
GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'

EXEC usp_ChangeJourneyPurpose 2, 'Educational'

EXEC usp_ChangeJourneyPurpose 196, 'Technical'