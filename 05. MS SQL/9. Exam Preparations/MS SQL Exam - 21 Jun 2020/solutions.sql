CREATE DATABASE TripService
GO
USE TripService
GO

-- 01.
CREATE TABLE Cities (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(20) NOT NULL,
    CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30) NOT NULL,
    CityId INT NOT NULL REFERENCES Cities(Id),
    EmployeeCount INT NOT NULL,
    BaseRate DECIMAL(8,2)
)

CREATE TABLE Rooms (
    Id INT PRIMARY KEY IDENTITY,
    Price DECIMAL(8,2) NOT NULL,
    Type NVARCHAR(20) NOT NULL,
    Beds INT NOT NULL,
    HotelId INT NOT NULL REFERENCES Hotels(Id)
)

CREATE TABLE Trips (
    Id INT PRIMARY KEY IDENTITY,
    RoomId INT NOT NULL REFERENCES Rooms(Id),
    BookDate DATE NOT NULL,
    ArrivalDate DATE NOT NULL,
    ReturnDate DATE NOT NULL,
    CancelDate DATE,
    CHECK (BookDate < ArrivalDate),
    CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(20),
    LastName NVARCHAR(50) NOT NULL,
    CityId INT NOT NULL REFERENCES Cities(Id),
    BirthDate DATE NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips (
    AccountId INT NOT NULL REFERENCES Accounts(Id),
    TripId INT NOT NULL REFERENCES Trips(Id),
    Luggage INT NOT NULL CHECK(Luggage >= 0),
    PRIMARY KEY (AccountId, TripId)
)

-- 02.
INSERT INTO Accounts VALUES
('John', 'Smith','Smith',34,'1975-07-21','j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

-- 03.
UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5, 7, 9)

--04.
DELETE AccountsTrips
WHERE AccountId = 47

-- 05.
SELECT 
    FirstName, 
    LastName, 
    FORMAT(BirthDate, 'MM-dd-yyyy') as BirthDate, 
    c.Name AS Hometown, 
    a.Email
FROM Accounts AS a 
JOIN Cities AS c ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name

-- 06.
SELECT 
    c.Name AS City, 
    COUNT(h.Id) AS Hotels
FROM Cities AS c 
JOIN Hotels AS h on h.CityId = c.Id
GROUP BY c.Name
ORDER BY Hotels DESC, City

-- 07.
SELECT 
    Id,
    FullName,
    MAX(TripDays) AS LongestTrip,
    MIN(TripDays) AS ShortestTrip
FROM (
    SELECT 
        a.Id, 
        CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
        DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS TripDays
    FROM Accounts AS a 
    JOIN AccountsTrips AS ac ON AccountId = a.Id
    JOIN Trips AS t ON t.Id = ac.TripId
    WHERE MiddleName IS NULL AND CancelDate IS NULL
) AS tripDays
GROUP BY Id, FullName
ORDER BY LongestTrip DESC, ShortestTrip

-- 08.
SELECT TOP 10
    c.Id, 
    c.Name, 
    c.CountryCode, 
    COUNT(a.Id) AS Accounts
FROM Cities AS c
JOIN Accounts AS a ON a.CityId = c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

-- 09.
SELECT a.Id, a.Email, c.Name, COUNT(t.Id) AS Trips
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON at.AccountId = a.Id
JOIN Trips AS t ON t.Id = at.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id

-- 10.
SELECT
    t.Id, 
    CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) AS FullName,
    ac.Name AS [From],
    hc.Name AS [To],
    CASE WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
        ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' ', 'days')
        END AS Duration
FROM Accounts AS a
JOIN AccountsTrips AS [at] ON at.AccountId = a.Id
JOIN Cities AS ac ON ac.Id = a.CityId
JOIN Trips AS t ON t.Id = at.TripId
JOIN Rooms AS r ON r.Id = t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS hc ON hc.Id = h.CityId
ORDER BY FullName, t.Id

-- 11.
GO
CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(70) AS
BEGIN
    DECLARE @Result VARCHAR(70) = (
        SELECT TOP 1
            CONCAT('Room ', r.Id,': ', r.[Type], ' ', '(',r.Beds, ' beds) - $', (h.BaseRate + r.Price) * 2)
        FROM Rooms AS r 
        JOIN Hotels AS h ON h.Id = r.HotelId
        JOIN Trips AS t ON t.RoomId = r.Id
        WHERE 
            h.Id = @HotelId AND 
            r.Beds >= @People AND
            r.Id NOT IN (
                SELECT RoomId 
                FROM Trips 
                WHERE @Date BETWEEN ArrivalDate AND ReturnDate AND CancelDate IS NULL
            )
        ORDER BY Price DESC
    )

    RETURN ISNULL(@Result, 'No rooms available') 
END
GO


SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

-- 12.
GO
CREATE OR ALTER PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT) AS
    DECLARE @HotelId INT = (
        SELECT TOP 1 r.HotelId
        FROM Trips AS t 
        JOIN Rooms AS r ON r.Id = t.RoomId
        WHERE t.Id = @TripId
    )

    DECLARE @TargetHotelId INT = (
        SELECT HotelId
        FROM Rooms
        WHERE Id = @TargetRoomId
    )

    IF (@HotelId <> @TargetHotelId)
        THROW 50001, 'Target room is in another hotel!', 1

    DECLARE @NeededBeds INT = (
        SELECT COUNT(*)
        FROM AccountsTrips
        WHERE TripId = @TripId
    )

    DECLARE @TargetRoomBeds INT = (
        SELECT Beds
        FROM Rooms
        WHERE Id = @TargetRoomId
    )

    IF (@NeededBeds > @TargetRoomBeds)
        THROW 50002, 'Not enough beds in target room!', 1

    UPDATE Trips
    SET RoomId = @TargetRoomId
    WHERE Id = @TripId

GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8