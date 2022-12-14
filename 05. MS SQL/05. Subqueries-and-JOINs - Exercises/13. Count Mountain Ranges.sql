  SELECT mc.CountryCode
	     ,COUNT(MountainId) AS MountainRanges
    FROM MountainsCountries AS mc
   WHERE mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY mc.CountryCode