USE SoftUni

-- 1.	Employees with Salary Above 35000
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT
		FirstName,
		LastName
	FROM Employees
	WHERE Salary > 35000
END

GO

EXEC usp_GetEmployeesSalaryAbove35000


-- 2.	Employees with Salary Above Number
GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4)) 
AS
BEGIN
	SELECT 
		FirstName, LastName
	FROM Employees
	WHERE Salary >= @Number
END

GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100


-- 3.	Town Names Starting With
GO

CREATE PROC usp_GetTownsStartingWith (@StartsWith VARCHAR(10)) 
AS
BEGIN
	SELECT
		[Name]
	FROM Towns
	WHERE [Name] LIKE @StartsWith + '%'
END

GO

EXEC usp_GetTownsStartingWith 'p'


-- 4.	Employees from Town
GO

CREATE PROC usp_GetEmployeesFromTown (@Town VARCHAR(50)) 
AS
BEGIN
	SELECT
		FirstName, LastName
	FROM Employees AS e
	JOIN Addresses AS a 
		ON e.AddressID = a.AddressID
	JOIN Towns AS t 
		ON t.TownID = a.TownID
		AND t.[Name] = @Town
END

GO

EXEC usp_GetEmployeesFromTown Sofia


-- 5.	Salary Level Function
GO

CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS VARCHAR(10) 
AS
BEGIN
	DECLARE @Result VARCHAR(10)
	SET @Result = 'High'

	IF (@salary < 30000)
		SET @Result = 'Low'
	ELSE IF (@salary <= 50000)
		SET @Result = 'Average'

	RETURN @Result
END

GO

SELECT
	Salary,
	dbo.ufn_GetSalaryLevel (Salary) AS [Salary Level]
FROM Employees


-- 6.	Employees by Salary Level
GO

CREATE PROC usp_EmployeesBySalaryLevel (@LevelOfSalary VARCHAR(10)) 
AS
BEGIN
	SELECT
		FirstName, 
		LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary
END

GO

EXEC usp_EmployeesBySalaryLevel 'high'


-- 7.	Define Function
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(20), @word VARCHAR(20))
RETURNS BIT 
AS
BEGIN
	DECLARE @currIndex TINYINT = 1
	DECLARE @currLetter CHAR(1)

	WHILE(@currIndex <= LEN(@word))
	BEGIN
		SET @currLetter = SUBSTRING(@word, @currIndex, 1)

		IF (CHARINDEX(@currLetter, @setOfLetters) = 0)
			BEGIN
				RETURN 0
			END

		SET @currIndex += 1
	END

	RETURN 1
END

GO

DECLARE @setOfLetters VARCHAR(10) = 'pppp'
DECLARE @word VARCHAR(10) = 'Guy'

SELECT 
	@setOfLetters AS SetOfLetters,
	@word AS Word,
	dbo.ufn_IsWordComprised(@setOfLetters, @word) AS Result

GO


-- 8.	* Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	--Delete all Employees from given Department in EmployeesProjects table
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN
	(
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID = @departmentId
	)
	--Make ManagerID column in Departments nullable
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT
	--Make ManagerID in Departments null for all Employees which manager will be deleted
	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId
	--Make ManagerID in Employees null for all Employees which manager will be deleted
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN
	(
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID = @departmentId
	)
	--Delete all Employees from given Department
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId
	--Delete given Department from Departments table
	DELETE FROM Departments
	WHERE DepartmentID = @departmentId
	--Return the number of Employees from the given Department (Should be zero)
	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 2

GO

-- 9.	Find Full Name
USE Bank

GO

CREATE OR ALTER PROC usp_GetHoldersFullName 
AS
BEGIN
	SELECT
		CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

GO

EXEC usp_GetHoldersFullName


-- 10.	People with Balance Higher Than
GO

CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan(@Number DECIMAL(18,2)) 
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM Accounts AS a
	JOIN AccountHolders AS ah 
		ON ah.Id = a.AccountHolderId
	GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @Number
	ORDER BY ah.FirstName, ah.LastName
END

GO

EXEC usp_GetHoldersWithBalanceHigherThan 10000


-- 11.	Future Value Function
GO

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(18,4), @InterestRate FLOAT, @Years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @Result DECIMAL(18,4)
	SET @Result = @Sum * (POWER((1 + @InterestRate), @YEARS))
	RETURN @Result
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)


-- 12.	Calculating Interest
GO

CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT) AS
BEGIN
	SELECT
		ah.Id AS [Account Id],
		ah.FirstName,
		ah.LastName,
		a.Balance,
		dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah 
		ON a.Id = ah.Id
	WHERE a.Id = @AccountId
END

GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1


-- 13.	*Scalar Function: Cash in User Games Odd Rows
USE Diablo

GO

CREATE OR ALTER FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(50))
RETURNS TABLE 
AS
RETURN
(
	SELECT SUM(dt.Cash) AS SumCash
	FROM
	(
		SELECT 
			ug.Cash,
			ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowNumber
		FROM UsersGames AS ug
		LEFT JOIN Games AS g
			ON g.Id = ug.GameId
		WHERE g.[Name] = @GameName
	) AS dt
	WHERE dt.RowNumber % 2 <> 0
)

GO

SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist')
