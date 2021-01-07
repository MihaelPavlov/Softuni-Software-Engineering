 -- Change primary key 

-- Composite Primary key

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07D56472AC

ALTER TABLE Users 
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY(Id,Username)

