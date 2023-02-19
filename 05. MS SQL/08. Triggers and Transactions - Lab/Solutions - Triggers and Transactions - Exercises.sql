USE Bank

-- 1.	Create Table Logs
CREATE TABLE Logs (
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL, 
	OldSum MONEY NOT NULL, 
	NewSum MONEY NOT NULL
)

GO
CREATE TRIGGER tr_CreateLogAfterChangeInAccounts
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT d.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON d.Id = i.Id
	WHERE i.Balance <> d.Balance
END
GO

UPDATE Accounts
SET Balance -= 10
WHERE Id = 1


-- 2.	Create Table Emails
CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT NOT NULL, 
	Subject VARCHAR(50) NOT NULL, 
	Body VARCHAR(100) NOT NULL
)

GO
CREATE OR ALTER TRIGGER tr_SendEmailWhenHaveNewRecordInLogs
ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, Subject, Body)
	SELECT 
		AccountId, 
		CONCAT('Balance change for account: ', AccountId),
		CONCAT('On ', GETDATE(), ' your balance was changed from ', OldSum, ' to ', NewSum, '.')
	FROM inserted
END
GO

UPDATE Accounts
SET Balance -= 10
WHERE Id = 1


-- 3.	Deposit Money
GO
CREATE OR ALTER PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18, 4)) 
AS
BEGIN
	IF @MoneyAmount > 0
		BEGIN
			UPDATE Accounts
			SET Balance += @MoneyAmount
			WHERE Id = @AccountId
		END
	ELSE
		BEGIN;
			THROW 50001, 'Invalid amount!', 1
		END
END
GO

EXEC usp_DepositMoney 1, 10
EXEC usp_DepositMoney 1, -10


-- 4.	Withdraw Money
GO
CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(18, 4)) 
AS
BEGIN
	IF (@MoneyAmount > 0)
		BEGIN
			UPDATE Accounts
			SET Balance = Balance - @MoneyAmount
			WHERE Id = @AccountId AND Balance >= @MoneyAmount
		END
	ELSE IF (@@ROWCOUNT <> 3)
		BEGIN;
			THROW 50001, 'Invalid amount!', 1
		END
END
GO

EXEC usp_WithdrawMoney 5, 10
EXEC usp_WithdrawMoney 5, -10


-- 5.	Money Transfer
GO
CREATE OR ALTER PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4)) 
AS
BEGIN TRANSACTION
	BEGIN TRY
		EXEC usp_WithdrawMoney @SenderId, @Amount
		EXEC usp_DepositMoney @ReceiverId, @Amount		
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW 50001, 'Invalid amount!', 1
	END CATCH
COMMIT
GO

EXEC usp_TransferMoney 5, 1, 100
EXEC usp_TransferMoney 5, 1, -100


-- 7.	*Massive Shopping
USE Diablo

GO
CREATE OR ALTER PROC usp_MassiveShoping @startLevel INT, @endLevel INT
AS
BEGIN TRANSACTION

	DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = 'Stamat')
	DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = 'Safflower')

	BEGIN TRY
		UPDATE UsersGames
		SET Cash -= (
			SELECT SUM(Price) 
			FROM Items 
			WHERE MinLevel BETWEEN @startLevel AND @endLevel
		)
		WHERE UserId = @userId AND GameId = @gameId
	END TRY
	BEGIN CATCH
		ROLLBACK;
		THROW 50001, 'Not enough money!', 1
		RETURN
	END CATCH

	DECLARE @itemsCount INT = (
		SELECT COUNT(*)
		FROM Items
		WHERE MinLevel BETWEEN @startLevel AND @endLevel
	)

	DECLARE @userGameId INT = (
		SELECT Id 
		FROM UsersGames 
		WHERE GameId = @gameId AND UserId = @userId
	)

	INSERT INTO UserGameItems ([ItemId], [UserGameId])
	SELECT Id, @userGameId AS UserGameId
	FROM Items
	WHERE MinLevel BETWEEN @startLevel AND @endLevel

	IF @@ROWCOUNT <> @itemsCount
	BEGIN
		ROLLBACK;
		THROW 50001, 'Invalid operation of insert the items!', 1
		RETURN
	END
COMMIT

EXEC usp_MassiveShoping 11, 12
EXEC usp_MassiveShoping 19, 21

SELECT [Name] AS [Item Name]
FROM UserGameItems AS ugi
LEFT JOIN Items AS i ON i.Id = ugi.ItemId
WHERE UserGameId = 110
ORDER BY i.[Name]

GO
-- 8.	Employees with Three Projects
USE [SoftUni]

GO
CREATE PROC [usp_AssignProject] (@emloyeeId INT, @projectID INT) AS
BEGIN TRANSACTION

	INSERT INTO [EmployeesProjects]
	VALUES (@emloyeeId, @projectID)

	DECLARE @projectsCount INT = (
		SELECT COUNT(*) 
		FROM [EmployeesProjects] 
		WHERE [EmployeeID] = @emloyeeId
	)

	IF @projectsCount > 3
	BEGIN
		ROLLBACK;
		THROW 50001, 'The employee has too many projects!', 1
		RETURN
	END
COMMIT


-- 9.	Delete Employees
CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	MiddleName VARCHAR(50), 
	JobTitle VARCHAR(50) NOT NULL, 
	DepartmentId INT NOT NULL, 
	Salary MONEY NOT NULL
) 

GO
CREATE OR ALTER TRIGGER [tr_FiredEmployees]
ON [Employees] FOR DELETE AS
BEGIN
	INSERT INTO [Deleted_Employees]
	SELECT 
		[EmployeeID], 
		[FirstName], 
		[LastName], 
		[MiddleName], 
		[JobTitle], 
		[DepartmentID], 
		[Salary]
	FROM [deleted]
END
GO