SELECT TOP 5 [dt].[Country],
			 [dt].[Highest Peak Name],
			 [dt].[Highest Peak Elevation],
			 [dt].[Mountain]
		FROM (
				  SELECT [c].[CountryName] AS [Country]
						 ,CASE WHEN [p].[PeakName] IS NULL THEN '(no highest peak)'
							   ELSE [p].[PeakName]
						 END AS [Highest Peak Name]
						 ,CASE WHEN [p].[Elevation] IS NULL THEN 0
							   ELSE [p].[Elevation]
						 END AS [Highest Peak Elevation]
						 ,CASE WHEN [m].[MountainRange] IS NULL THEN '(no mountain)'
							   ELSE [m].[MountainRange]
						 END AS [Mountain]
						 ,DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC) AS [Rank]
					FROM [Countries] AS [c]
			   LEFT JOIN [MountainsCountries] AS [mc] 
					  ON [mc].[CountryCode] = [c].[CountryCode]
			   LEFT JOIN [Mountains] AS [m] 
					  ON [m].[Id] = [mc].[MountainId]
			   LEFT JOIN [Peaks] AS [p] 
					  ON [p].[MountainId] = [m].[Id]
			 ) AS [dt]
       WHERE [dt].[Rank] = 1