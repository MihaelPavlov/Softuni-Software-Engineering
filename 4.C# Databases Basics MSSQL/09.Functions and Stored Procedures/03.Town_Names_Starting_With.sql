CREATE PROCEDURE usp_GetTownsStartingWith (@string nvarchar(10))
AS
BEGIN
	SELECT [Name] FROM Towns
	WHERE [Name] LIKE @string + '%'
END

EXEC usp_GetTownsStartingWith c