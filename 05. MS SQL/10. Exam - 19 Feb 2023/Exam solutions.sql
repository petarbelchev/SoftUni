CREATE DATABASE Boardgames
GO
USE Boardgames
GO

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses
(
    Id INT PRIMARY KEY IDENTITY,
    StreetName NVARCHAR(100) NOT NULL,
    StreetNumber INT NOT NULL,
    Town VARCHAR(30) NOT NULL,
    Country VARCHAR(50) NOT NULL,
    ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(30) NOT NULL UNIQUE,
    AddressId INT NOT NULL REFERENCES Addresses(Id),
    Website NVARCHAR(40),
    Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges
(
    Id INT PRIMARY KEY IDENTITY,
    PlayersMin INT NOT NULL,
    PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30) NOT NULL,
    YearPublished INT NOT NULL,
    Rating DECIMAL(4,2) NOT NULL,
    CategoryId INT NOT NULL REFERENCES Categories(Id),
    PublisherId INT NOT NULL REFERENCES Publishers(Id),
    PlayersRangeId INT NOT NULL REFERENCES PlayersRanges(Id)
)

CREATE TABLE Creators
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
    CreatorId INT NOT NULL REFERENCES Creators(Id),
    BoardgameId INT NOT NULL REFERENCES Boardgames(Id),
    PRIMARY KEY (CreatorId, BoardgameId)
)

-- 02.
INSERT INTO Boardgames VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas',	2020, 3.25, 3, 7, 4),
('One Small Step',	2019, 5.75,	5,	9,	2)

INSERT INTO Publishers VALUES
('Agman Games',	5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games',	7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks',	13, 'www.battlebooks.com', '+12345678907')

-- 03.
UPDATE PlayersRanges 
SET PlayersMax += 1 
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET Name = Name + 'V2'
WHERE YearPublished >= 2020

-- 04.
DELETE CreatorsBoardgames
WHERE BoardgameId IN (
    SELECT Id 
    FROM Boardgames 
    WHERE PublisherId IN (
        SELECT Id
        FROM Publishers 
        WHERE AddressId IN (
            SELECT Id 
            FROM Addresses 
            WHERE Town LIKE 'L%'
        )
    )
)

DELETE Boardgames 
WHERE PublisherId IN (
    SELECT Id
    FROM Publishers 
    WHERE AddressId IN (
        SELECT Id 
        FROM Addresses 
        WHERE Town LIKE 'L%'
    )
)

DELETE Publishers 
WHERE AddressId IN (
    SELECT Id 
    FROM Addresses 
    WHERE Town LIKE 'L%'
)

DELETE Addresses 
WHERE Town LIKE 'L%'

-- 05.
SELECT Name, Rating
FROM Boardgames
ORDER BY YearPublished, Name DESC

-- 06.
SELECT 
    b.Id, 
    b.Name, 
    b.YearPublished, 
    c.Name AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY b.YearPublished DESC

-- 07.
SELECT 
    c.Id, 
    CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName, 
    c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
WHERE cb.CreatorId IS NULL
ORDER BY CreatorName

-- 08.
SELECT TOP 5 
    b.Name, 
    b.Rating, 
    c.Name AS CategoryName
FROM Boardgames AS b 
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE 
    (b.Rating > 7 AND b.Name LIKE '%a%') OR
    (b.Rating > 7.5 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5)
ORDER BY b.Name, b.Rating DESC

-- 09.
SELECT
    CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
    c.Email,
    MAX(b.Rating) AS Rating
FROM Creators AS c 
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
WHERE Email LIKE '%.com'
GROUP BY c.FirstName, c.LastName, c.Email

-- 10.
SELECT 
    c.LastName, 
    CEILING(AVG(b.Rating)) AS AverageRating, 
    p.Name
FROM Creators AS c 
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE p.Name = 'Stonemaier Games'
GROUP BY p.Name, c.LastName
ORDER BY AVG(b.Rating) DESC

-- 11.
GO
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30)) 
RETURNS INT AS
BEGIN
    RETURN (
        SELECT COUNT(*)
        FROM Creators AS c 
        JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
        WHERE FirstName = @name
    )
END
GO

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

-- 12.
GO
CREATE PROC usp_SearchByCategory(@category VARCHAR(50)) AS
    SELECT 
        b.Name, 
        b.YearPublished, 
        b.Rating, 
        c.Name AS CategoryName, 
        p.Name AS PublisherName,
        CONCAT(pr.PlayersMin, ' people') AS MinPlayers,
        CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
    FROM Categories AS c 
    JOIN Boardgames AS b ON b.CategoryId = c.Id
    JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
    JOIN Publishers AS p ON p.Id = b.PublisherId
    WHERE c.Name = @category
    ORDER BY p.Name, b.YearPublished DESC
GO