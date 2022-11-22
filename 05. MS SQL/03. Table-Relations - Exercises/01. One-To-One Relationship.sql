CREATE TABLE [Passports] (
	[PassportID] INT PRIMARY KEY IDENTITY(101, 1),
	[PassportNumber] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Persons] (
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[Salary] DECIMAL (8,2) NOT NULL,
	[PassportId] INT NOT NULL UNIQUE FOREIGN KEY REFERENCES [Passports]([PassportID])	
)

INSERT INTO [Passports]
	 VALUES ('N34FG21B')
			,('K65LO4R7')
			,('ZE657QP2')

INSERT INTO [Persons]
	 VALUES ('Roberto', 43300, 102)
			,('Tom', 56100, 103)
			,('Yana', 60200, 101)