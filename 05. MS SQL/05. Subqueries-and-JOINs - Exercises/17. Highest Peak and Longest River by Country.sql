SELECT TOP 5 [dt].[CountryName]
			 ,[dt].[HighestPeakElevation]
			 ,[dt].[LongestRiverLength]
		FROM (
				   SELECT [c].[CountryName]
					      ,[p].[Elevation] AS [HighestPeakElevation]
					      ,[r].[Length] AS [LongestRiverLength]
					      ,RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC, [r].[Length] DESC) AS [Rank]
				     FROM [Countries] AS [c]
				FULL JOIN [MountainsCountries] AS [mc] ON [c].[CountryCode] = [mc].[CountryCode]
				FULL JOIN [Mountains] AS [m] ON [m].[Id] = [mc].[MountainId]
				FULL JOIN [Peaks] AS [p] ON [p].[MountainId] = [m].[Id]
				FULL JOIN [CountriesRivers] AS [cr] ON [cr].[CountryCode] = [c].[CountryCode]
				FULL JOIN [Rivers] AS [r] ON [r].[Id] = [cr].[RiverId]
		     ) AS [dt]
       WHERE [dt].[Rank] = 1
    ORDER BY [dt].[HighestPeakElevation] DESC, [dt].[LongestRiverLength] DESC