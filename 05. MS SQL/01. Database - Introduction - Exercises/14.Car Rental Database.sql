-- Problem 14.	Car Rental Database
CREATE DATABASE [CarRental]

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(2,1) NOT NULL,
	[WeeklyRate] DECIMAL(2,1) NOT NULL,
	[MonthlyRate] DECIMAL(2,1) NOT NULL,
	[WeekendRate] DECIMAL(2,1) NOT NULL
)

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] INT NOT NULL,
	[Manufacturer] NVARCHAR(50) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear] SMALLINT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Doors] TINYINT NOT NULL,
	[Picture] VARBINARY,
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Condition] NVARCHAR(10) NOT NULL,
	[Available] BIT NOT NULL
)

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(15) NOT NULL,
	[LastName] NVARCHAR(15) NOT NULL,
	[Title] NVARCHAR(10) NOT NULL,
	[Notes] NVARCHAR(100)
)

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	[City] NVARCHAR(20) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(100)
)

CREATE TABLE [RentalOrders] (
	[Id] INT PRIMARY KEY IDENTITY, 
	[EmployeeId] INT NOT NULL, 
	[CustomerId] INT NOT NULL, 
	[CarId] INT NOT NULL, 
	[TankLevel] TINYINT NOT NULL,
	CHECK ([TankLevel] >= 0 AND [TankLevel] <= 100),
	[KilometrageStart] INT NOT NULL, 
	[KilometrageEnd] INT NOT NULL, 
	[TotalKilometrage] INT NOT NULL, 
	[StartDate] DATE NOT NULL, 
	[EndDate] DATE NOT NULL, 
	[TotalDays] INT NOT NULL, 
	[RateApplied] DECIMAL(2,1) NOT NULL, 
	[TaxRate] TINYINT NOT NULL, 
	[OrderStatus] BIT NOT NULL, 
	[Notes] NVARCHAR(100)
)

INSERT INTO [Categories]
	([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
	('Sedan', 9.2, 6.2, 7.8, 9.0),
	('Hatchback', 6.2, 4.2, 8.9, 6.8),
	('SUV', 8.2, 7.3, 9.4, 5.8)

INSERT INTO [Cars]
	([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Condition], [Available])
VALUES
	(239489, 'VW', 'PASSAT', 1999, 1, 4, 'USED', 1),
	(439588, 'BWM', 'X5', 2022, 3, 4, 'NEW', 1),
	(329849, 'MERCEDES', 'A-CLASS', 2007, 2, 4, 'USED', 0)

INSERT INTO [Employees]
	([FirstName], [LastName], [Title])
VALUES
	('Ivan', 'Ivanov', 'Seller'),
	('Petar', 'Petrov', 'Seller'),
	('Kevin', 'Johnson', 'Seller')

INSERT INTO [Customers]
	([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode])
VALUES
	(928398, 'Martin Martinov', 'Bolnichna Str.', 'Kazanlak', 2398),
	(450499, 'Kiril Kirilov', 'Hristo Botev Str.', 'Plovdiv', 0923),
	(230923, 'Hristo Hristov', 'Vasil Levski Str.', 'Sofia', 4346)

INSERT INTO [RentalOrders]
	([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus])
VALUES
	(2, 1, 3, 90, 10000, 10600, 600, '2022-11-12', '2022-11-14', 2, 6.2, 5.4, 1),
	(1, 3, 2, 100, 15320, 16320, 1000, '2022-11-10', '2022-11-13', 3, 6.2, 5.4, 1),
	(3, 2, 1, 80, 15320, 16320, 1000, '2022-11-10', '2022-11-13', 3, 6.2, 5.4, 1)