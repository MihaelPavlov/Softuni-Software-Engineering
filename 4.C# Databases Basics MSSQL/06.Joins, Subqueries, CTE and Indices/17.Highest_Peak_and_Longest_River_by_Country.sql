SELECT TOP(5) c.CountryName, MAX(p.Elevation)AS HighestPeakElevatio,
MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c 
LEFT OUTER JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
LEFT OUTER JOIN  Mountains AS m 
ON mc.MountainId = m.Id
LEFT OUTER JOIN Peaks AS p 
ON p.MountainId = m.Id
LEFT OUTER JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r 
ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC , MAX(r.[Length]) DESC , c.CountryName


