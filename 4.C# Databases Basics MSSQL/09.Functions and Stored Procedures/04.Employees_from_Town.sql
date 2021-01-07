CREATE  PROCEDURE usp_GetEmployeesFromTown (@town NVARCHAR(30))
AS 
BEGIN
	SELECT e.[FirstName],e.[LastName] FROM Employees AS e
	INNER JOIN Addresses AS a 
	ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t
	ON t.TownID = a.TownID
	WHERE @town = t.[Name]
END


EXEC usp_GetEmployeesFromTown 'Sofia'

