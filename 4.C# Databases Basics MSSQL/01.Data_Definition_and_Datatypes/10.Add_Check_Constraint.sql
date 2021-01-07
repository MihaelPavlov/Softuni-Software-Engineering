-- add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_Users_Password CHECK(DATALENGTH([Password])>=5 )