--Create database

CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	Id INT IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_Town PRIMARY KEY (Id)
)

CREATE TABLE Addresses
(
	Id INT   IDENTITY,
	AddressText NVARCHAR(MAX) NOT NULL,
	TownId INT ,
	CONSTRAINT PK_Addresses PRIMARY KEY (Id),
	CONSTRAINT FK_Addresses_Towns FOREIGN KEY (TownId) REFERENCES Towns (Id)
)


CREATE TABLE Departments
(
	Id INT  IDENTITY,
	[Name] NVARCHAR(200) NOT NULL
	CONSTRAINT PK_Department PRIMARY KEY(Id)
)
CREATE TABLE Employees
(
	Id INT   IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	JobTittle NVARCHAR(30) NOT NULL,
	DepartmentId INT  ,
	HireDate DATE ,
	Salary DECIMAL (15,1),
	AddressId INT ,
	CONSTRAINT PK_Employees PRIMARY KEY (Id),
	CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId) REFERENCES Departments (Id),
	CONSTRAINT FK_Employees_Addresses FOREIGN KEY (AddressId) REFERENCES Addresses (Id),
	CONSTRAINT CK_Employees_Salary CHECK (Salary >= 0)
)