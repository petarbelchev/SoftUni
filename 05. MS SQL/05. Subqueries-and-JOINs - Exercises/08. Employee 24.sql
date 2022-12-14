SELECT e.EmployeeID
	   ,e.FirstName
	   ,CASE WHEN p.StartDate < '2005-01-01' THEN p.[Name]
			 ELSE NULL
		END ProjectName
  FROM Employees AS e
  JOIN EmployeesProjects AS ep
    ON e.EmployeeID = 24
   AND e.EmployeeID = ep.EmployeeID
  JOIN Projects AS p
    ON ep.ProjectID = p.ProjectID