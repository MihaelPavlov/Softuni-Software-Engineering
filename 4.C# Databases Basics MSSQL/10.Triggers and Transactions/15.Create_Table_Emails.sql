CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY , 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] VARCHAR(50),
	Body VARCHAR(MAX) 
)


GO

CREATE OR ALTER TRIGGER tr_LogsReports ON Logs
FOR INSERT 
AS
	
	DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted);
	DECLARE @oldSum DECIMAL(15,2) = (SELECT OldSum FROM inserted);
	DECLARE @newSum DECIMAL(15,2) = (SELECT NewSum FROM inserted);

	INSERT INTO NotificationEmails (Recipient , [Subject] ,Body) VALUES
	(@accountId ,
	'Balance change for account: ' + CAST(@accountId AS VARCHAR(20)),
	'On ' + CONVERT(varchar(30),GETDATE() , 103) + ' your balance was changed from ' + CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20)) + '.')

UPDATE Accounts 
SET Balance +=10
WHERE Id = 1
