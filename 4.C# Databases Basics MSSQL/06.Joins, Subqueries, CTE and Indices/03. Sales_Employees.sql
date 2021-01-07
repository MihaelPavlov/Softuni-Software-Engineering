SELECT e.EmployeeID ,e.FirstName, e.LastName ,d.[Name] FROM Employees AS e 
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC
