CREATE DATABASE Airport

GO

USE Airport

GO

-- 01.

CREATE TABLE Passengers (
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL,
	Rating FLOAT, 
	CONSTRAINT CHK_Age CHECK (Age BETWEEN 21 AND 62),
	CONSTRAINT CHK_Rating CHECK (Rating BETWEEN 0.0 AND 10.0)
)

CREATE TABLE AircraftTypes (
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft (
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft (
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PilotId INT NOT NULL FOREIGN KEY REFERENCES Pilots(Id),
	PRIMARY KEY (AircraftId, PilotId)
)

CREATE TABLE Airports (
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL,
)

CREATE TABLE FlightDestinations (
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
	Start DATETIME NOT NULL,
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)

-- 02.

INSERT INTO Passengers 
SELECT *
FROM (
	SELECT 
		CONCAT(FirstName, ' ', LastName) AS FullName,
		CONCAT(FirstName,LastName,'@gmail.com') AS Email
	FROM Pilots
	WHERE Id BETWEEN 5 AND 15
) AS [dt]

-- 03.

UPDATE Aircraft
SET Condition = 'A'
WHERE 
	(Condition = 'C' OR Condition = 'B') AND
	(FlightHours IS NULL OR FlightHours <= 100) AND
	[Year] > 2013

-- 04.

DELETE Passengers
WHERE DATALENGTH(FullName) <= 10

-- 05.

SELECT 
	Manufacturer,
	Model,
	FlightHours,
	Condition
FROM Aircraft
ORDER BY FlightHours DESC

-- 06.

SELECT 
	p.FirstName,
	p.LastName,
	a.Manufacturer,
	a.Model,
	a.FlightHours
FROM Pilots AS p
JOIN PilotsAircraft AS pa ON pa.PilotId = p.Id
JOIN Aircraft AS a ON a.Id = pa.AircraftId
WHERE a.FlightHours <= 304
ORDER BY 
	a.FlightHours DESC,
	p.FirstName

-- 07.

SELECT TOP 20
	fd.Id AS DestinationId,
	Start,
	p.FullName,
	a.AirportName,
	fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Passengers AS p ON p.Id = fd.PassengerId
JOIN Airports AS a ON a.Id = fd.AirportId
WHERE DAY(Start) % 2 = 0
ORDER BY 
	fd.TicketPrice DESC,
	a.AirportName

-- 08.

SELECT *
FROM (
	SELECT 
		a.Id AS AircraftId,
		a.Manufacturer,
		MAX(a.FlightHours) AS FlightHours,
		COUNT(*) AS FlightDestinationsCount,
		ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
	FROM Aircraft AS a
	JOIN FlightDestinations AS fd ON fd.AircraftId = a.Id
	GROUP BY a.Id, a.Manufacturer
) AS dt
WHERE dt.FlightDestinationsCount >= 2
ORDER BY 
	dt.FlightDestinationsCount DESC,
	dt.AircraftId

-- 09.

SELECT 
	dt.FullName, 
	COUNT(dt.FullName) AS CountOfAircraft, 
	SUM(dt.TicketPrice) AS TotalPayed
FROM (
	SELECT 
		p.FullName, 
		fd.TicketPrice
	FROM Passengers AS p
	JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
	GROUP BY 
		p.FullName,
		fd.TicketPrice
	HAVING SUBSTRING(p.FullName, 2, 1) = 'a'
) AS dt
GROUP BY dt.FullName
HAVING COUNT(dt.FullName) > 1
ORDER BY dt.FullName

-- 10.

SELECT 
	ap.AirportName,
	fd.Start AS DayTime,
	fd.TicketPrice,
	p.FullName,
	ai.Manufacturer,
	ai.Model
FROM FlightDestinations AS fd
JOIN Airports AS ap ON ap.Id = fd.AirportId
JOIN Passengers AS p ON p.Id = fd.PassengerId
JOIN Aircraft AS ai	ON ai.Id = fd.AircraftId
WHERE 
	(DATEPART(HOUR, Start) BETWEEN 6 AND 19) AND
	fd.TicketPrice > 2500
ORDER BY ai.Model

-- 11.

GO

CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail (@email VARCHAR(50))
RETURNS INT AS
BEGIN
	RETURN (
		SELECT COUNT(*)
		FROM FlightDestinations
		WHERE PassengerId = (
			SELECT Id
			FROM Passengers
			WHERE Email = @email
		)
	)
END

GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

-- 12.

GO

CREATE OR ALTER PROC usp_SearchByAirportName (@airportName VARCHAR(70)) AS
	SELECT 
		ap.AirportName,
		p.FullName,
		CASE 
			WHEN fd.TicketPrice <= 400 THEN 'Low'
			WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
			WHEN fd.TicketPrice > 1500 THEN 'High'
		END AS LevelOfTickerPrice,
		ac.Manufacturer,
		ac.Condition,
		act.TypeName
	FROM Airports AS ap
	JOIN FlightDestinations AS fd ON fd.AirportId = ap.Id
	JOIN Passengers AS p ON p.Id = fd.PassengerId
	JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
	JOIN AircraftTypes AS act ON act.Id = ac.TypeId
	WHERE ap.AirportName = @airportName
	ORDER BY
		ac.Manufacturer,
		p.FullName

GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'