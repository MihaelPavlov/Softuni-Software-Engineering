SELECT e1.EmployeeID , e1.FirstName , e1.ManagerID ,e2.FirstName FROM Employees AS e1
INNER JOIN Employees AS e2 
ON e1.ManagerID = e2.EmployeeID
WHERE e1.ManagerID IN(3,7)
ORDER BY e1.EmployeeID ASC



