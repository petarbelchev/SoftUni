CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL 
)

CREATE TABLE RepositoriesContributors (
	RepositoryId INT NOT NULL,
	ContributorId INT NOT NULL,
	PRIMARY KEY (RepositoryId, ContributorId),
	FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id),
	FOREIGN KEY (ContributorId)REFERENCES Users(Id)
)

CREATE TABLE Issues (
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL,
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Commits (
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL, -- ONLY CHAR()???
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Files (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(18, 2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT NOT NULL REFERENCES Commits(Id)
)

INSERT INTO Files
VALUES
	('Trade.idk', 2598.0, 1, 1),	
	('menu.net', 9238.31, 2, 2),
	('Administrate.soshy', 1246.93, 3, 3),
	('Controller.php', 7353.15, 4, 4),
	('Find.java', 9957.86, 5, 5),
	('Controller.json', 14034.87, 3, 6),
	('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues
VALUES
	('Critical Problem with HomeController.cs file', 'open', 1, 4),
	('Typo fix in Judge.html', 'open', 4, 3),
	('Implement documentation for UsersService.cs', 'closed', 8, 2),
	('Unreachable code in Index.cs', 'open', 9, 8)

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

DELETE FROM RepositoriesContributors
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

SELECT Id, [Message], RepositoryId, ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

SELECT Id, [Name], Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]

SELECT 
	i.Id,
	CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues AS i
LEFT JOIN Users AS u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, i.AssigneeId

SELECT Id, [Name], CONCAT(Size, 'KB') AS Size
FROM Files
WHERE Id NOT IN (SELECT ParentId FROM Files GROUP BY ParentId HAVING ParentId IS NOT NULL)
ORDER BY Id, [Name], Size DESC


-- Problem 9.
SELECT TOP 5 
	r.Id, 
	r.[Name], 
	COUNT(*) AS Commits
FROM Repositories AS r
LEFT JOIN Commits AS c 
	ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc 
	ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY COUNT(*) DESC, r.Id, r.[Name] 



-- Problem 10.
SELECT u.Username, AVG(Size) AS Size
FROM Users AS u
JOIN Commits AS c
	ON c.ContributorId = u.Id
JOIN Files AS f
	ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY AVG(Size) DESC, u.Username


-- Problem 11.
GO
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30)) 
RETURNS INT AS
BEGIN
	DECLARE @result INT = ( 
		SELECT COUNT(*)
		FROM Commits
		WHERE ContributorId = (SELECT Id FROM Users WHERE Username = @username)
	)
	RETURN @result
END
GO
SELECT dbo.udf_AllUserCommits('UnderSinduxrein')


-- Problem 12.
GO
CREATE OR ALTER PROC usp_SearchForFiles(@fileExtension VARCHAR(10)) AS
BEGIN
	SELECT 
		Id, 
		[Name], 
		CONCAT(Size, 'KB') AS Size
	FROM Files
	WHERE [Name] LIKE '%.' + @fileExtension
END
GO

EXEC usp_SearchForFiles 'txt'