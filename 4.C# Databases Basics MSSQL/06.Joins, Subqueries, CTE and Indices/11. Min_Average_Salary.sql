SELECT TOP(1)  avg(Salary)as Average FROM Employees AS e 
INNER JOIN Departments AS d 
ON e.DepartmentID = d.DepartmentID
GROUP BY D.[Name]
ORDER BY Average ASC

