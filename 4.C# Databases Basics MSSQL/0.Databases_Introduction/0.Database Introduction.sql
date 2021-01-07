CREATE DATABASE Minions

CREATE TABLE Minions
(
	Id INT PRIMARY KEY ,
	[Name] NVARCHAR(30) NOT NULL,
	Age INT NOT NULL
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY ,
	[Name] NVARCHAR(30) NOT NULL,
)

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)


INSERT INTO Towns(Id, [Name]) VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')


INSERT INTO Minions(Id, [Name] , Age , TownId) VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

SELECT [Id] ,[Name],[Age], [TownId] FROM Minions

TRUNCATE TABLE Minions
DROP TABLE Minions
DROP TABLE Towns


GO


--Create table People

CREATE TABLE People 
(
	Id INT UNIQUE IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height FLOAT(2),
	[Weight] FLOAT(2),
	Gender  CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX),
	CONSTRAINT PK_People PRIMARY KEY(Id),
	CONSTRAINT CK_Peple_Gender CHECK(Gender='m' OR Gender='f')
)



INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
	('Maria', 011010101, 1.64, 65.77, 'f', '1985/01/17', 'Marias Bio'),
	('Peter', 01111101, 1.88, 87.00, 'm', '1980/06/11', 'Peters Bio'),
	('Ida', 100000001, 1.64, 65.77, 'f', '1985/05/03', 'Idas Bio'),
	('Nia', 000011010, 1.70, 60.52, 'f', '1975/06/06', 'Nias Bio'),
	('Tom', 101010101, 1.90, 85.7, 'm', '1995/08/08', 'Toms Bio')

	SELECT* FROM People



	--Create table Users
GO

CREATE TABLE Users 
(
 Id BIGINT PRIMARY KEY IDENTITY,
 Username  NVARCHAR(30)  UNIQUE NOT NULL,
 [Password] NVARCHAR(26) NOT NULL,
 ProfilePicture VARBINARY(MAX) ,
 CHECK(DATALENGTH(ProfilePicture) <=921600),
 LastLoginTime DATETIME2 ,
 IsDeleted BIT NOT NULL,
)


INSERT INTO Users (Username ,
[Password] , ProfilePicture,
LastLoginTime,IsDeleted
) VALUES
('Pesho','123',NULL,NULL,0),
('DADA','123',NULL,NULL,0),
('P3123esho','123',NULL,NULL,0),
('gOHO','123',NULL,NULL,1),
('rOKO','123',NULL,NULL,1)

SELECT* FROM Users
