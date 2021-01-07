--CREATE NEW DATABASE

CREATE DATABASE CarRental

CREATE TABLE Categories
(
  Id INT PRIMARY KEY IDENTITY,
  CategoryName NVARCHAR(MAX) NOT NULL,
  DailyRate NUMERIC(15,1) NOT NULL,
  WeeklyRate NUMERIC(15,1) NOT NULL ,
  MonthlyRate NUMERIC(15,1) NOT NULL,
  WeekendRate NUMERIC(15,1) NOT NULL
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(20) NOT NULL,
	Manufacturer NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20)NOT NULL ,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture VARBINARY(MAX) ,
	Condition NVARCHAR(30),
	Available BIT NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30)NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL , 
	Notes NVARCHAR(MAX) 
)


CREATE TABLE Customers
(
   Id INT PRIMARY KEY IDENTITY ,
   DriverLicenceNumber NVARCHAR(30) NOT NULL,
   FullName NVARCHAR(60) NOT NULL,
   [Address] NVARCHAR(50),
   City NVARCHAR(30) ,
   ZIPCode INT NOT NULL,
   Notes NVARCHAR(MAX) 
)

CREATE TABLE RentalOrders
(
   Id INT PRIMARY KEY IDENTITY,
   EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
   CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
   CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
   TankLevel INT NOT NULL,
   KilometrageStart INT NOT NULL,
   KilometrageEnd INT NOT NULL,
   TotalKilometrage INT NOT NULL ,
   StartDate DATE NOT NULL,
   EndDate DATE NOT NULL,
   TotalDays INT NOT NULL,
   RateApplied NUMERIC(15,1) NOT NULL ,
   TaxRate NUMERIC(15,1) NOT NULL,
   OrderStatus BIT NOT NULL,
   Notes NVARCHAR(MAX)

)
 
INSERT INTO Categories (CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate) VALUES
('Volov' , 8.5,3.5,3.2,3.1),('BMW' , 8.5,3.5,3.2,3.1),('Ferrari' , 10.0,8,6.2,7.1)

INSERT INTO Cars (PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Picture,Condition,Available) VALUES
('AM-000-BM','London' ,'23','0001-01-02',1,4,NULL,'Perfect' , 1),
('bM-02010-BM','Germany' ,'100','0002-01-01',2,4,NULL,'NOTBad' , 0),
('A2-057-B1','England' ,'65','0003-01-01',3,4,NULL,'Perfect' , 1)

INSERT INTO Employees(FirstName,LastName,Title,Notes) VALUES
('Michael' , 'Kerov' ,'Roko',NULL),
('Ignasio' , 'Peshov' ,'Ignite',NULL),
('Pesho' , 'Mero' ,'Kotio',NULL)

INSERT INTO Customers(DriverLicenceNumber,FullName,[Address],City,ZIPCode,Notes) VALUES
('YES' , 'MichaelKerov','Street', 'Sofia', 5500 , NULL),
('NO' , 'IgnasioPeshov','Street', 'London', 123 , NULL),
('YES' , 'PeshoMero','Street', 'Lovech', 4131 , NULL)

INSERT INTO RentalOrders (EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage,
StartDate,EndDate,TotalDays,RateApplied,TaxRate,OrderStatus,Notes) VALUES
(2,1,2,100,0,200,200,'0002-01-01','0201-02-01',20,9.9,200,1,NULL),
(1,1,3,100,0,200,200,'0002-01-01','0001-03-01',20,9.9,200,0,NULL),
(1,1,3,100,0,200,200,'0003-01-01','0031-04-01',20,9.9,200,1,NULL)

SELECT * FROM RentalOrders