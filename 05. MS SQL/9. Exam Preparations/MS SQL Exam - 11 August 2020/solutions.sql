CREATE DATABASE Bakery
GO
USE Bakery
GO

-- 01.

CREATE TABLE Countries (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(25),
    LastName NVARCHAR(25),
    Gender CHAR(1) CHECK(Gender IN('M', 'F')),
    Age INT,
    PhoneNumber CHAR(10),
    CountryId INT REFERENCES Countries(Id)
)

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(25) UNIQUE,
    Description NVARCHAR(250),
    Recipe NVARCHAR(MAX),
    Price DECIMAL(18,2) CHECK(Price >= 0)
)

CREATE TABLE Feedbacks (
    Id INT PRIMARY KEY IDENTITY,
    Description NVARCHAR(255),
    Rate DECIMAL(4,2) CHECK(Rate BETWEEN 0 AND 10),
    ProductId INT REFERENCES Products(Id),
    CustomerId INT REFERENCES Customers(Id)
)

CREATE TABLE Distributors (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(25) UNIQUE,
    AddressText NVARCHAR(30),
    Summary NVARCHAR(200),
    CountryId INT REFERENCES Countries(Id)
)

CREATE TABLE Ingredients (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(30),
    Description NVARCHAR(200),
    OriginCountryId INT REFERENCES Countries(Id),
    DistributorId INT REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients (
    ProductId  INT NOT NULL REFERENCES Products(Id),
    IngredientId  INT NOT NULL REFERENCES Ingredients(Id),
    PRIMARY KEY (ProductId, IngredientId)
)

-- 02.

INSERT INTO Distributors(Name, CountryId, AddressText, Summary) VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

-- 03.

UPDATE Ingredients 
SET DistributorId = 35
WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients 
SET OriginCountryId = 14
WHERE OriginCountryId = 8

-- 04.

DELETE Feedbacks 
WHERE CustomerId = 14 OR ProductId = 5

-- 05.

SELECT Name, Price, Description 
FROM Products 
ORDER BY Price DESC, Name

-- 06.

SELECT f.ProductId, f.Rate, f.Description, f.CustomerId, c.Age, c.Gender
FROM Feedbacks AS f 
JOIN Customers AS c ON c.Id = f.CustomerId
WHERE Rate < 5
ORDER BY ProductId DESC, Rate

-- 07.

SELECT
    CONCAT(FirstName, ' ', LastName) AS CustomerName
    ,PhoneNumber, Gender
FROM Customers
WHERE Id NOT IN (SELECT CustomerId FROM Feedbacks)
ORDER BY Id

-- 08.

SELECT FirstName, Age, PhoneNumber
FROM Customers
WHERE 
    (Age >= 21 AND FirstName LIKE '%an%') OR
    (PhoneNumber LIKE '%38' AND CountryId <> 31)
ORDER BY FirstName, Age DESC

-- 09.

SELECT *
FROM (
    SELECT 
        d.Name AS DistributorName
        ,i.Name AS IngredientName
        ,p.Name AS ProductName
        ,AVG(f.Rate) AS AverageRate
    FROM Distributors AS d
    JOIN Ingredients AS i ON i.DistributorId = d.Id
    JOIN ProductsIngredients AS pi ON pi.IngredientId = i.Id
    JOIN Products AS p ON p.Id = pi.ProductId
    JOIN Feedbacks AS f ON f.ProductId = p.Id
    GROUP BY d.Name, i.Name, p.Name
) AS dt
WHERE AverageRate BETWEEN 5 AND 8
ORDER BY DistributorName, IngredientName, ProductName

-- 10.

SELECT CountryName, DisributorName
FROM (
    SELECT 
        c.Name AS CountryName
        ,d.Name AS DisributorName
        ,RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS Rank
    FROM Countries AS c 
    LEFT JOIN Distributors AS d ON d.CountryId = c.Id
    LEFT JOIN Ingredients AS i ON i.DistributorId = d.Id
    WHERE d.Name IS NOT NULL
    GROUP BY c.Name, d.Name
) AS dt
WHERE Rank = 1
ORDER BY CountryName, DisributorName

-- 11.

GO
CREATE VIEW v_UserWithCountries AS
    SELECT 
        CONCAT(cu.FirstName, ' ', cu.LastName) AS CustomerName
        ,cu.Age
        ,cu.Gender
        ,cou.Name AS CountryName
    FROM Customers AS cu
    JOIN Countries AS cou ON cou.Id = cu.CountryId
GO

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

-- 12.

GO
CREATE TRIGGER dbo.UponDeleteProduct ON Products
INSTEAD OF DELETE AS
    DECLARE @ProductId INT = (SELECT Id FROM deleted)
    DELETE Feedbacks WHERE ProductId = @ProductId
    DELETE ProductsIngredients WHERE ProductId = @ProductId
    DELETE Products WHERE Id = @ProductId

GO

DELETE FROM Products WHERE Id = 7