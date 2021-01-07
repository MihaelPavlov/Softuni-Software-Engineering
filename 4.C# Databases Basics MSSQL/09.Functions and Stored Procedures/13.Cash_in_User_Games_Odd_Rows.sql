CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(20))
RETURNS TABLE
AS
RETURN 
	SELECT  SUM(Q.Cash) AS [SumCash] FROM (
		SELECT g.[Name] ,ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS [Rows],ug.Cash   FROM UsersGames AS ug
		INNER JOIN Games AS g
		ON g.Id = ug.GameId
		WHERE @gameName = g.[Name]
		) AS Q
WHERE Q.[Rows] % 2 <>0

	

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')