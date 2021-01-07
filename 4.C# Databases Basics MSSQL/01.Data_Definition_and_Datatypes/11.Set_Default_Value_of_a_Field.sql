-- Set default Value of a Field
 -- With GETDATE() -we get the current time
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime
 --Test
INSERT INTO Users 
(Username,[Password],ProfilePicture,IsDeleted) VALUES
('Test','123',NULL,1)

SELECT * FROM Users