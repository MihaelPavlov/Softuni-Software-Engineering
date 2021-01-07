SELECT TOP(5) c.CountryName ,r.RiverName
	FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr 
ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r
ON cr.RiverId = r.Id
JOIN Continents AS con
on c.ContinentCode = con.ContinentCode
WHERE con.ContinentName IN ('Africa')
ORDER BY c.CountryName
