
--Set Unique Field

ALTER TABLE Users 
ADD CONSTRAINT CK_Users_Username 
UNIQUE (Username),
CHECK (DATALENGTH(Username)>=3)
