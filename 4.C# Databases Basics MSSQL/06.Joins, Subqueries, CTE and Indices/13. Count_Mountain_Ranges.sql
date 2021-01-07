SELECT mc.CountryCode,COUNT(c.CountryCode)AS MountainRanges FROM Countries AS c
INNER JOIN MountainsCountries AS mc 
ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains AS m 
ON mc.MountainId = m.Id
WHERE c.CountryName IN ('United States','Russia','Bulgaria')
GROUP BY mc.CountryCode
