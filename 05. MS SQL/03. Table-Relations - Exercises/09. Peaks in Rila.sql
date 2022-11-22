SELECT MountainRange, PeakName, Elevation
FROM Mountains
JOIN Peaks ON
	 Mountains.Id = Peaks.MountainId
	 AND Peaks.MountainId = 17
ORDER BY Elevation DESC