SELECT g.[Name] AS [Game],
		gt.[Name] AS[Game Type],
		u.Username , ug.[Level],
		ug.Cash , c.[Name] AS [Character]
FROM UsersGames AS ug
INNER JOIN Users AS u 
ON ug.UserId = u.Id
INNER JOIN Games AS g 
ON g.Id = ug.GameId
INNER JOIN Characters AS c 
ON c.Id = ug.CharacterId
INNER JOIN GameTypes AS gt
ON g.GameTypeId = gt.Id
WHERE g.IsFinished = 1
ORDER BY ug.[Level] DESC , u.Username ASC, g.[Name] ASC



