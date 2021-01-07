CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN

	--Delete all record from EmployeesProject where EmployeeId need to be delete it.
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
					--First make Query , where get EmployeeID thats need to be delete it 
						SELECT EmployeeID FROM Employees 
						WHERE DepartmentID = @departmentId	
						)
	-- Set ManagerID to NULL where Manager is an Employee who is going be delete it. (For Employees)
	UPDATE Employees 
	SET ManagerID = NULL
	WHERE ManagerID IN (
						SELECT EmployeeID FROM Employees 
						WHERE DepartmentID = @departmentId	
						)
		--Alter column ManagerID in Departments Table and make it nullable.
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	-- Set ManagerId TO null where manager is and Employee who is going to be delete it (Departments)
	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
					SELECT EmployeeID FROM Employees 
			WHERE DepartmentID = @departmentId	
			)
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 1