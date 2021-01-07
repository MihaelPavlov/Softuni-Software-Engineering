CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount (@accountId INT , @yir FLOAT)
AS
BEGIN
		SELECT TOP(1) ah.Id , FirstName,LastName,Balance , dbo.ufn_CalculateFutureValue(Balance,@yir,5) AS[Balanced in 5 Years] FROM AccountHolders AS ah
		INNER JOIN Accounts AS a
		ON a.AccountHolderId = ah.Id
		WHERE @accountId = ah.Id
END
		
exec usp_CalculateFutureValueForAccount 1,0.1