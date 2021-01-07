SELECT TOP(50)e1.EmployeeID ,
CONCAT(e1.FirstName,' ' , e1.LastName) AS EmployeeName,
CONCAT(e2.FirstName, ' ', e2.LastName) AS ManagerName,
d.[Name]
FROM Employees AS e1
INNER JOIN Employees AS e2 ON e1.ManagerID = e2.EmployeeID
INNER JOIN Departments AS d ON e1.DepartmentID = d.DepartmentID
ORDER BY e1.EmployeeID


