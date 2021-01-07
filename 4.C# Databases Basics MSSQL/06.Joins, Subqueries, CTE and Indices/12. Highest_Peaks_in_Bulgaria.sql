SELECT mc.CountryCode,m.MountainRange , p.PeakName,p.Elevation FROM MountainsCountries as mc
INNER JOIN Mountains AS m 
ON mc.MountainId = m.Id
INNER JOIN Peaks AS p 
ON p.MountainId = mc.MountainId
WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
ORDER BY P.Elevation DESC
