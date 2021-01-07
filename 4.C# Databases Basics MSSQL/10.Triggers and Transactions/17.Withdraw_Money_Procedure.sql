CREATE OR ALTER PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN
DECLARE @money DECIMAL (15,2) = (SELECT Balance FROM Accounts WHERE @accountId = Id);
IF EXISTS
	(
		SELECT Id FROM Accounts
		WHERE @accountId= Id
	)
		BEGIN
			IF(@moneyAmount > @money )
			BEGIN
				RAISERROR('Not Enough Money! ' ,16,1)
				RETURN
			END
				ELSE
				BEGIN
				UPDATE Accounts
				SET Balance -= @moneyAmount
				WHERE Id = @accountId
				END
		END

END