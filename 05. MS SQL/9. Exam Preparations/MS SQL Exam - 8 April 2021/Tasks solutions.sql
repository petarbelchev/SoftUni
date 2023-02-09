CREATE DATABASE Service

GO

USE Service

GO

-- 01.

CREATE TABLE Users(
    Id INT PRIMARY KEY IDENTITY,
    Username VARCHAR(30) UNIQUE NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Name VARCHAR(50),
    Birthdate DATETIME,
    Age INT CHECK(Age BETWEEN 14 AND 110),
    Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    Birthdate DATETIME,
    Age INT CHECK(Age BETWEEN 18 AND 110),
    DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50) NOT NULL,
    DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Status (
    Id INT PRIMARY KEY IDENTITY,
    Label VARCHAR(20) NOT NULL
)

CREATE TABLE Reports (
    Id INT PRIMARY KEY IDENTITY,
    CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
    StatusId INT NOT NULL FOREIGN KEY REFERENCES Status(Id),
    OpenDate DATETIME NOT NULL,
    CloseDate DATETIME,
    Description VARCHAR(200) NOT NULL,
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

-- 02.

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId) VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

-- 03.

UPDATE Reports
SET Closedate = GETDATE()
WHERE CloseDate IS NULL

-- 04.

DELETE Reports
WHERE StatusId = 4

-- 05.

SELECT Description, FORMAT(OpenDate, 'dd-MM-yyyy')
FROM Reports 
WHERE EmployeeId IS NULL
ORDER BY OpenDate, Description

-- 06.

SELECT r.Description, ca.Name AS CategoryName
FROM Reports AS r 
JOIN Categories AS ca ON ca.Id = r.CategoryId
ORDER BY r.Description, ca.Name

-- 07.

SELECT c.Name AS CategoryName, COUNT(*) AS ReportsNumber
FROM Categories AS c 
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC

-- 08.

SELECT u.Username, c.Name AS CategoryName
FROM Users AS u 
JOIN Reports AS r ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE 
    DATEPART(DAY, u.BirthDate) = DATEPART(DAY, r.OpenDate) AND
    DATEPART(MONTH, u.BirthDate) = DATEPART(MONTH, r.OpenDate)
ORDER BY u.Username, CategoryName

-- 09.

SELECT dt.FullName, COUNT(*) AS UsersCount
FROM (
    SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName, r.UserId
    FROM Employees AS e 
    JOIN Reports AS r ON r.EmployeeId = e.Id
) AS dt
GROUP BY dt.FullName
ORDER BY UsersCount DESC, dt.FullName

-- 10.

SELECT 
    CASE 
        WHEN e.FirstName IS NULL AND e.LastName IS NULL THEN 'None'
        ELSE CONCAT(e.FirstName, ' ', e.LastName)
        END AS FullName,
    d.Name AS Department,
    c.Name AS Category,
    r.Description,
    FORMAT(r.OpenDate, 'dd.MM.yyyy'),
    s.Label AS [Status],
    u.Name AS [User]
FROM Reports AS r 
LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
JOIN Categories AS c ON c.Id = r.CategoryId
JOIN [Status] AS s ON s.Id = r.StatusId
JOIN Users AS u on u.Id = r.UserId
ORDER BY
    e.FirstName DESC,
    e.LastName DESC,
    d.Name,
    c.Name,
    r.Description,
    r.OpenDate,
    s.Label,
    u.Name

-- 11.

GO

CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT AS
BEGIN
    IF(@StartDate IS NULL OR @EndDate IS NULL)
        RETURN 0
    
    RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
FROM Reports

-- 12.

GO

CREATE OR ALTER PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) AS
    DECLARE @EmpDepId INT = (
        SELECT DepartmentId
        FROM Employees
        WHERE Id = @EmployeeId
    )

    DECLARE @RepDepId INT = (
        SELECT c.DepartmentId
        FROM Reports AS r 
        JOIN Categories AS c ON c.Id = r.CategoryId
        WHERE r.Id = @ReportId
    )

    IF(@EmpDepId <> @RepDepId)
        THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

    UPDATE Reports
    SET EmployeeId = @EmployeeId
    WHERE Id = @ReportId
GO

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2