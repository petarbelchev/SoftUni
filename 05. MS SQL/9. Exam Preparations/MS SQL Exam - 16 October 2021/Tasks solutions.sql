CREATE DATABASE CigarShop

GO

USE CigarShop

GO

-- 01.

CREATE TABLE Sizes (
	Id INT PRIMARY KEY IDENTITY,
	Length INT NOT NULL CHECK (Length BETWEEN 10 AND 25),
	RingRange DECIMAL(2,1) CHECK (RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes (
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL,
)

CREATE TABLE Brands (
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars (
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(Id),
	TastId INT NOT NULL FOREIGN KEY REFERENCES Tastes(Id),
	SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id),
	PriceForSingleCigar DECIMAL(18,2) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL	
)

CREATE TABLE Clients (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars (
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(Id),
	CigarId INT NOT NULL FOREIGN KEY REFERENCES Cigars(Id),
	PRIMARY KEY (ClientId, CigarId)
)

-- 02.
INSERT INTO Cigars VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

-- 03.

UPDATE Cigars
SET [PriceForSingleCigar] *= 1.2
WHERE TastId = (
	SELECT Id 
	FROM Tastes 
	WHERE TasteType = 'Spicy'
)

UPDATE Brands
SET BrandDescription = 'New description'
WHERE [BrandDescription] IS NULL

-- 04.

DELETE Clients
WHERE AddressId IN (
	SELECT Id
	FROM Addresses
	WHERE Country LIKE 'C%'
)

DELETE Addresses
WHERE Country LIKE 'C%'

-- 05.

SELECT 
	CigarName, 
	PriceForSingleCigar, 
	ImageURL
FROM Cigars
ORDER BY 
	PriceForSingleCigar, 
	CigarName

-- 06.

SELECT 
	c.Id, 
	c.CigarName, 
	c.PriceForSingleCigar, 
	t.TasteType, 
	t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t ON t.Id = c.TastId
WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC

-- 07.

SELECT 
	Id,
	CONCAT(FirstName, ' ', LastName) AS ClientName,
	Email
FROM Clients 
WHERE Id NOT IN (
	SELECT DISTINCT ClientId 
	FROM ClientsCigars
)
ORDER BY ClientName

-- 08.

SELECT TOP 5 
	c.CigarName,
	c.PriceForSingleCigar,
	c.ImageURL
FROM Cigars AS c
JOIN Sizes AS s ON s.Id = c.SizeId
WHERE 
	s.Length >= 12 AND
	(c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND
	s.RingRange > 2.55
ORDER BY 
	c.CigarName,
	c.PriceForSingleCigar DESC

-- 09.

SELECT 
	dt.FullName,
	dt.Country,
	dt.ZIP,
	CONCAT('$', MAX(dt.PriceForSingleCigar)) AS CigarPrice
FROM (
	SELECT 
		CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
		a.Country,
		a.ZIP,
		ci.PriceForSingleCigar
	FROM Clients AS c 
	JOIN Addresses AS a ON a.Id = c.AddressId
	JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
	JOIN Cigars AS ci ON ci.Id = cc.CigarId
	WHERE a.ZIP NOT LIKE '%[^0-9]%'
) AS dt
GROUP BY 
	dt.FullName,
	dt.Country,
	dt.ZIP
ORDER BY dt.FullName

-- 10.

SELECT 
	c.LastName,
	AVG(s.Length) AS CigarLength,
	CEILING(AVG(s.RingRange)) AS CigarRingRange
FROM Clients AS c 
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS ci ON ci.Id = cc.CigarId
JOIN Sizes AS s ON s.Id = ci.SizeId
GROUP BY c.LastName
ORDER BY CigarLength DESC

-- 11.

GO

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT AS
BEGIN
	RETURN (
		SELECT COUNT(*) 
		FROM ClientsCigars 
		WHERE ClientId = (
			SELECT Id 
			FROM Clients 
			WHERE FirstName = @name
		)
	)
END

GO

SELECT dbo.udf_ClientWithCigars('Betty')

-- 12.

GO

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20)) AS
	SELECT
		c.CigarName,
		CONCAT('$', c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.Length, ' cm') AS CigarLength,
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars AS c
	JOIN Brands AS b ON b.Id = c.BrandId
	JOIN Sizes AS s ON s.Id = c.SizeId
	JOIN Tastes AS t ON t.Id = c.TastId
	WHERE t.TasteType = @taste
	ORDER BY 
		s.Length,
		s.RingRange DESC

GO

EXEC usp_SearchByTaste 'Woody'