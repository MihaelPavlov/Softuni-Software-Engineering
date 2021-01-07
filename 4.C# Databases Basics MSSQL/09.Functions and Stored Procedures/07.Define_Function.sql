CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @isComprised bit = 0;
	DECLARE @counter INT = 1;
	DECLARE @currentChar char;
	
	WHILE(@counter <= LEN(@word))
	BEGIN
		SET @currentChar = SUBSTRING(@word,@counter,1);
		IF(CHARINDEX(@currentChar,@setOfLetters) = 0)
		BEGIN
			RETURN @isComprised;
		END
		SET @counter +=1;		
	END
	RETURN @isComprised + 1;
END


CREATE TABLE TestDB (SetOfLetters varchar(max), Word varchar(max))
GO

INSERT INTO TestDB VALUES 
  ('oistmiahf', 'Sofia'), ('oistmiahf', 'halves'), ('bobr', 'Rob'), ('pppp', 'Guy'), ('', 'empty')
GO


SELECT SetOfLetters, Word,
  dbo.ufn_IsWordComprised(SetOfLetters, Word) AS Result
FROM TestDB