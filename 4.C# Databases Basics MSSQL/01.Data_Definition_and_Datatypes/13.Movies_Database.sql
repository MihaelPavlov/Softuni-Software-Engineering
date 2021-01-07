--CREATE

CREATE DATABASE Movies

--Tables 
CREATE TABLE Directors
(
 Id INT PRIMARY KEY IDENTITY,
 DirectorName NVARCHAR(30) NOT NULL,
 Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Genres
(
 Id INT PRIMARY KEY IDENTITY,
 GenreName NVARCHAR(30) NOT NULL,
 Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Categories
(
 Id INT PRIMARY KEY IDENTITY ,
 CategoryName NVARCHAR(30) NOT NULL,
 Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Movies
(
  Id INT PRIMARY KEY IDENTITY NOT NULL,
  Title NVARCHAR(50) NOT NULL UNIQUE,
  DirectorId INT  FOREIGN KEY REFERENCES Directors (Id) NOT NULL,
  CopyrightYear INT NOT NULL,
  [Length] INT NOT NULL,
  GenreId INT FOREIGN KEY REFERENCES Genres (Id) NOT NULL,
  CategoryId INT FOREIGN KEY REFERENCES Categories (Id) NOT NULL,
  Rating NUMERIC(15,1) ,
  Notes NVARCHAR(MAX),

  CONSTRAINT CK_Movies_Rating CHECK(Rating>0 AND Rating<=10)

)

INSERT INTO Directors (DirectorName, Notes) VALUES
('Misho' ,'FirstMovie'),
('Gosho' ,'SecondMovie'),
('Stamat' ,'ThirdMovie'),
('GoshkoBrother','FourMovie'),
('Ignasio','FiveMovie')


INSERT INTO Genres (GenreName, Notes) VALUES
('Drama','Sad'),
('Action' ,'Cool'),
('Comedy' ,'Funny'),
('Bad','Very bad'),
('VeryBad',' bad')


INSERT INTO Categories (CategoryName , Notes) VALUES
('S','Expensive'),
('A','Middle'),
('C','Low'),
('F' , 'Very Low'),
('F--' ,'Insane Low')


INSERT INTO Movies (Title,DirectorId,CopyrightYear,[Length], GenreId,CategoryId,Rating,Notes) VALUES
('Matrix' , 1, 2002,155,2,2,9.9,'The best Movie'),
('Superman' , 2, 2002,155,4,1,9.9,'The best Movie'),
('BakingZero' , 3, 2002,155,5,1,1.5,'Movie'),
('SuperGril' , 2, 2002,155,1,2,2.9,'Movie'),
('ProgramingJokes' , 4, 2002,155,3,4,5.9,'Movie')


SELECT * From Movies






