CREATE TABLE Cities 
(
	CityID INT IDENTITY PRIMARY KEY , 
	[Name] VARCHAR(50)
)
CREATE TABLE Customers
(
	CustomerID INT IDENTITY PRIMARY KEY , 
	[Name] VARCHAR(50),
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)
CREATE TABLE Orders
(
	OrderID INT IDENTITY PRIMARY KEY ,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)
CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY,
	[Name] VARCHAR(50)
)
CREATE TABLE Items
(
	ItemID INT PRIMARY KEY  ,
	[Name]  VARCHAR(50),
	ItemTypeID  INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) 
)
CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	PRIMARY KEY (OrderID , ItemID)
)