SELECT e.EmployeeID , e.FirstName , 
CASE
	WHEN DATEPART(YEAR,p.StartDate) >= 2005 THEN NULL
	ELSE P.[Name]
	END AS [Name]
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24 



