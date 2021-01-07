CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number INT)
AS
BEGIN 
	
		SELECT FirstName,LastName FROM Accounts AS a
		INNER JOIN AccountHolders AS ah
		ON a.AccountHolderId = ah.Id
		GROUP BY  ah.Id ,FirstName , LastName
		HAVING SUM(Balance) > @number
		ORDER BY FirstName , LastName
END

exec usp_GetHoldersWithBalanceHigherThan 10000

