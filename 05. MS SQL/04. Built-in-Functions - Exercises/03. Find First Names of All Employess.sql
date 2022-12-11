SELECT FirstName
FROM Employees
WHERE (YEAR(HireDate) >= 1995 AND YEAR(HireDate) <= 2005) AND 
	  (DepartmentID = 3 OR DepartmentID = 10)