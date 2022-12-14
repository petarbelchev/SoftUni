SELECT e.EmployeeID
	   ,e.FirstName
	   ,m.EmployeeID
	   ,m.FirstName AS ManagerName
  FROM Employees AS e
  JOIN Employees AS m
    ON e.ManagerID = m.EmployeeID
   AND m.EmployeeID IN (3, 7)