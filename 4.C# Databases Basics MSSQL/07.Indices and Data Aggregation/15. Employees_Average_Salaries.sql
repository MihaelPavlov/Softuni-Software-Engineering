SELECT * 
INTO EmployeesMoreThan30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesMoreThan30000
WHERE ManagerId = 42

UPDATE EmployeesMoreThan30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT
  DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesMoreThan30000
GROUP BY DepartmentID  

