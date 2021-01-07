CREATE PROCEDURE usp_TransferMoney(@senderId INT,@receiverId INT, @amount DECIMAL(15,2))
AS 
BEGIN
BEGIN TRANSACTION 
	EXEC usp_WithdrawMoney @senderId,@amount
	EXEC usp_DepositMoney @receiverId , @amount
	COMMIT
	
END

go
