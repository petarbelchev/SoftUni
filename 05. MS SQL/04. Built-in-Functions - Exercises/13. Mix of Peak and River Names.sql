SELECT PeakName
	   ,RiverName
	   ,CONCAT(LOWER(PeakName), SUBSTRING(LOWER(RiverName), 2, LEN(RiverName))) AS Mix
FROM Peaks
JOIN Rivers ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix