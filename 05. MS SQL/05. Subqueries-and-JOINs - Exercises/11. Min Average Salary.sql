SELECT MIN(e.avSalaries) AS MinAverageSalary
  FROM (SELECT AVG(Salary) AS avSalaries
	   FROM Employees
	   GROUP BY DepartmentID) 
    AS e