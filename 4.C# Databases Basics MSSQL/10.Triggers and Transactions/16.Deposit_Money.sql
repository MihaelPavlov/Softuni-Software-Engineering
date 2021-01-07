CREATE or alter PROCEDURE usp_DepositMoney(@accountId INT ,  @moneyAmount DECIMAL(15,4))
AS
BEGIN
	IF EXISTS
	(
		SELECT Id FROM Accounts
		WHERE @accountId= Id
	)
		BEGIN
			IF(@moneyAmount > 0 )
			BEGIN
				UPDATE Accounts
				SET Balance += @moneyAmount
				WHERE Id = @accountId
			END
		END
END

GO
-- Solutin ~ 2

CREATE OR ALTER PROCEDURE usp_DepositMoney(@accountId INT ,  @moneyAmount DECIMAL(15,4))
AS
BEGIN
BEGIN TRANSACTION 
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId);
		IF(@account IS NULL )
		BEGIN
			ROLLBACK 
			RAISERROR('Invalid account id!' , 16,1)
			RETURN
		END
		IF(@moneyAmount > 0)
		BEGIN
			ROLLBACK
			RAISERROR('Negative amount!' , 16,1)
			RETURN
		END

			UPDATE Accounts
			SET Balance += @moneyAmount
			WHERE Id = @accountId
		COMMIT
END


