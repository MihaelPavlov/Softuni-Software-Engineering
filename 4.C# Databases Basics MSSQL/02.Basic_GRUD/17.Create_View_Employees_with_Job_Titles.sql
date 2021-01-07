CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName +' '+coalesce(MiddleName,'')+' '+ LastName AS FullName,JobTitle 
FROM Employees

-- coalesce is return the first not null value in the scobe()



