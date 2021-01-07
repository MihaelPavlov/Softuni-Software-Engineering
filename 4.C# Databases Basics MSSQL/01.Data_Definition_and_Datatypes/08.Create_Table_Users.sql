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