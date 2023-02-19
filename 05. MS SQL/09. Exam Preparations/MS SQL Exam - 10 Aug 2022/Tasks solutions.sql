CREATE DATABASE NationalTouristSitesOfBulgaria

GO

USE NationalTouristSitesOfBulgaria

GO

-- 01.

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
)

CREATE TABLE Locations
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    Municipality VARCHAR(50),
    Province VARCHAR(50),
)

CREATE TABLE Sites
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100) NOT NULL,
    LocationId INT NOT NULL FOREIGN KEY REFERENCES Locations(Id),
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
    Establishment VARCHAR(15)
)

CREATE TABLE Tourists
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    Age INT NOT NULL CHECK (Age BETWEEN 0 AND 120),
    PhoneNumber VARCHAR(20) NOT NULL,
    Nationality VARCHAR(30) NOT NULL,
    Reward VARCHAR(20)
)

CREATE TABLE SitesTourists
(
    TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
    SiteId INT NOT NULL FOREIGN KEY REFERENCES Sites(Id),
    PRIMARY KEY (TouristId, SiteId)
)

CREATE TABLE BonusPrizes
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes
(
    TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
    BonusPrizeId INT NOT NULL FOREIGN KEY REFERENCES BonusPrizes(Id),
    PRIMARY KEY (TouristId, BonusPrizeId)
)

-- 02.

INSERT INTO Tourists
VALUES
    ('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
    ('Peter Bosh', 48, '+447911844141', 'UK', NULL),
    ('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
    ('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
    ('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites
VALUES
    ('Ustra fortress', 90, 7, 'X'),
    ('Karlanovo Pyramids', 65, 7, NULL),
    ('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
    ('Sinite Kamani Natural Park', 17, 1, NULL),
    ('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

-- 03.

UPDATE Sites 
SET Establishment = 'not defined' 
WHERE Establishment IS NULL

-- 04.

DELETE TouristsBonusPrizes 
WHERE BonusPrizeId = (
    SELECT Id
    FROM BonusPrizes
    WHERE Name = 'Sleeping bag'
)

DELETE BonusPrizes
WHERE Name = 'Sleeping bag'

-- 05.

SELECT
    Name,
    Age,
    PhoneNumber,
    Nationality
FROM Tourists
ORDER BY 
    Nationality, 
    Age DESC, 
    Name

-- 06.

SELECT
    s.Name AS Site,
    l.Name AS Location,
    s.Establishment,
    c.Name AS Category
FROM Sites AS s
    JOIN Locations AS l ON l.Id = s.LocationId
    JOIN Categories AS c ON c.Id = s.CategoryId
ORDER BY 
    Category DESC, 
    Location, 
    Site

-- 07.

SELECT
    l.Province,
    l.Municipality,
    l.Name AS Location,
    COUNT(*) AS CountOfSites
FROM Locations AS l
    JOIN Sites AS s ON s.LocationId = l.Id
GROUP BY 
    l.Name,
    l.Municipality,
    l.Province
HAVING l.Province = 'Sofia'
ORDER BY 
    CountOfSites DESC, 
    Location

-- 08.

SELECT
    s.Name AS Site,
    l.Name AS Location,
    l.Municipality,
    l.Province,
    s.Establishment
FROM Sites AS s
    JOIN Locations AS l ON l.Id = s.LocationId
WHERE 
    s.Name NOT LIKE'B%' AND
    s.Name NOT LIKE 'M%' AND
    s.Name NOT LIKE 'D%' AND
    s.Establishment LIKE '%BC%'
ORDER BY Site

-- 09.

SELECT
    t.Name,
    t.Age,
    t.PhoneNumber,
    t.Nationality,
    CASE WHEN bp.Name IS NULL THEN '(no bonus prize)'
        ELSE bp.Name
        END AS Reward
FROM Tourists AS t
    LEFT JOIN TouristsBonusPrizes AS tbp ON tbp.TouristId = t.Id
    LEFT JOIN BonusPrizes AS bp ON bp.Id = tbp.BonusPrizeId
ORDER BY t.Name

-- 10.

SELECT
    SUBSTRING(t.Name, CHARINDEX(' ', t.Name) + 1, LEN(t.Name)) AS LastName,
    t.Nationality,
    t.Age,
    t.PhoneNumber
FROM Tourists AS t
    JOIN SitesTourists AS st ON st.TouristId = t.Id
    JOIN Sites AS s ON s.Id = st.SiteId
    JOIN Categories AS c ON c.Id = s.CategoryId
WHERE c.Name = 'History and archaeology'
GROUP BY 
    t.Name, 
    t.Nationality, 
    t.Age, 
    t.PhoneNumber
ORDER BY LastName

-- 11.
GO

CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100)) 
RETURNS INT AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM SitesTourists
        WHERE SiteId = (
            SELECT Id
            FROM Sites
            WHERE Name = @Site
        )
    )
END

GO

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum ? Vratsa')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')

-- 12.

GO

CREATE PROC usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
    DECLARE @CountOfSites INT = (
        SELECT COUNT(*)
        FROM SitesTourists
        WHERE TouristId IN (
            SELECT Id
            FROM Tourists
            WHERE Name = @TouristName
        )
    )

    DECLARE @Reward VARCHAR(20)

    IF(@CountOfSites >= 100) SET @Reward = 'Gold badge'
    ELSE IF(@CountOfSites >= 50) SET @Reward = 'Silver badge'
    ELSE IF(@CountOfSites >= 25) SET @Reward = 'Bronze badge'

    UPDATE Tourists
    SET Reward = @Reward
    WHERE Name = @TouristName

    SELECT Name, @Reward
    FROM Tourists
    WHERE Name = @TouristName
END

GO

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'

EXEC usp_AnnualRewardLottery 'Teodor Petrov'

EXEC usp_AnnualRewardLottery 'Zac Walsh'

EXEC usp_AnnualRewardLottery 'Brus Brown'