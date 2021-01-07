CREATE TABLE Logs 
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum DECIMAL(18,2) ,
	NewSum DECIMAL(18,2)
)

GO

CREATE TRIGGER tr_ChangeOldSum ON Accounts 
FOR UPDATE
AS
	DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted)
	DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM deleted)
	DECLARE @accountID INT = (SELECT Id FROM inserted)

	INSERT INTO Logs(AccountId,OldSum,NewSum) VALUES
	(@accountID,@oldSum ,@newSum) 

	UPDATE Accounts
	SET Balance += 10
	WHERE Id = 1




UPDATE Logs SET NewSum = 200