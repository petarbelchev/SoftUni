CREATE DATABASE WMS

GO

USE WMS

GO

-- 01.

CREATE TABLE Clients (
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone VARCHAR(12) CHECK(DATALENGTH(Phone) = 12)
)

CREATE TABLE Mechanics (
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models (
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs (
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(ModelId),
	Status VARCHAR(11) CHECK(Status IN ('Pending', 'In Progress', 'Finished')) DEFAULT 'Pending',
	ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientId),
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders (
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT DEFAULT 0
)

CREATE TABLE Vendors (
	VendorId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts (
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	Description VARCHAR(255),
	Price DECIMAL(6,2) CHECK(Price > 0),
	VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL DEFAULT 0 CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts (
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT 1 CHECK(Quantity > 0),
	PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded (
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT 1 CHECK(Quantity > 0),
	PRIMARY KEY(JobId, PartId)
)

-- 02.

INSERT INTO Clients VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, Description, Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

-- 03.

UPDATE Jobs
SET MechanicId = 3, Status = 'In Progress'
WHERE Status = 'Pending'

-- 04.

DELETE OrderParts WHERE OrderId = 19

DELETE Orders WHERE OrderId = 19

-- 05.

SELECT 
	CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	j.Status,
	j.IssueDate
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY 
	m.MechanicId, 
	j.IssueDate, 
	j.JobId

-- 06.

SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS Client,
	DATEDIFF(DAY, j.IssueDate, '4/24/2017') AS [Days going],
	j.Status
FROM Clients AS c 
LEFT JOIN Jobs AS j ON j.ClientId = c.ClientId 
WHERE j.Status <> 'Finished'
ORDER BY [Days going] DESC, c.ClientId

-- 07.

SELECT 
	dt.Mechanic,
	AVG(dt.Days) AS [Average Days]
FROM (
	SELECT 
		m.MechanicId,
		CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
		DATEDIFF(DAY, j.IssueDate, j.FinishDate) AS Days
	FROM Mechanics AS m 
	LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId 
	WHERE j.Status = 'Finished'
) AS dt
GROUP BY dt.Mechanic, dt.MechanicId
ORDER BY dt.MechanicId

-- 08.

SELECT
	CONCAT(FirstName, ' ', LastName) AS Available
FROM Mechanics 
WHERE MechanicId NOT IN (
	SELECT DISTINCT MechanicId 
	FROM Jobs 
	WHERE 
		Status <> 'Finished' AND 
		MechanicId IS NOT NULL
)
ORDER BY MechanicId

-- 09.

SELECT
	j.JobId,
	ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
FROM Jobs AS j
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

-- 10.

SELECT *
FROM (
	SELECT
	p.PartId
	,p.Description
	,SUM(pn.Quantity) AS Required
	,SUM(p.StockQty) AS [In Stock]
	,CASE WHEN o.OrderId IS NULL THEN 0 
		ELSE SUM(op.Quantity) 
		END AS Ordered
	FROM Jobs AS j
	JOIN PartsNeeded AS pn ON pn.JobId = j.JobId
	JOIN Parts AS p ON p.PartId = pn.PartId
	LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
	LEFT JOIN Orders AS o ON o.JobId = j.JobId
	WHERE j.Status <> 'Finished'
	GROUP BY p.PartId, p.Description, o.OrderId
) AS dt
WHERE dt.Required > dt.[In Stock] + dt.Ordered
ORDER BY dt.PartId

-- 11.

GO

CREATE OR ALTER PROC usp_PlaceOrder(@JobId INT, @SerialNumber VARCHAR(50), @Quantity INT) AS
	IF ((SELECT Status FROM Jobs WHERE JobId = @JobId) = 'Finished')
		THROW 50011, 'This job is not active!', 1

	IF (@Quantity < 1)
		THROW 50012, 'Part quantity must be more than zero!', 1

	IF ((SELECT JobId FROM Jobs WHERE JobId = @JobId) <> @JobId)
		THROW 50013, 'Job not found!', 1

	IF ((SELECT SerialNumber FROM Parts WHERE SerialNumber = @SerialNumber) <> @SerialNumber)
		THROW 50014, 'Part not found!', 1
		
	DECLARE @PartId INT = (SELECT PartId FROM Parts	WHERE SerialNumber = @SerialNumber)
	
	-- Here we check that is we have open Order
	IF ((SELECT COUNT(*) FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL) <> 0)
		BEGIN
			DECLARE @OrderId INT = (SELECT OrderId FROM Orders	WHERE JobId = @JobId AND IssueDate IS NULL)

			-- After we have open order we check is we have that part in it
			IF ((SELECT COUNT(*) FROM OrderParts WHERE OrderId = @OrderId AND PartId = @PartId) <> 0)
				BEGIN
					UPDATE OrderParts
					SET Quantity += @Quantity
					WHERE OrderId = @OrderId AND PartId = @PartId
				END
			-- Add the part to the order when we dont have it in the order 
			ELSE
				BEGIN
					INSERT INTO OrderParts VALUES
					(@OrderId, @PartId, @Quantity)
				END
		END
	-- As we dont have opened Order we create it
	ELSE
		BEGIN
			INSERT INTO Orders(JobId, IssueDate) VALUES	(@JobId, NULL)

			SET @OrderId = (SELECT OrderId FROM Orders WHERE JobId = @JobId AND IssueDate IS NULL)

			INSERT INTO OrderParts VALUES
			(@OrderId, @PartId, @Quantity)
		END

GO

DECLARE @err_msg AS NVARCHAR(MAX);

BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

-- 12.

GO

CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(8,2) AS
BEGIN
	RETURN ( 
		SELECT ISNULL(SUM(p.Price), 0) AS Result
		FROM Orders AS o
		LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
		LEFT JOIN Parts AS p ON p.PartId = op.PartId
		WHERE o.JobId = @JobId
	)
END

GO

SELECT dbo.udf_GetCost(3)