ALTER TABLE Minions
ADD TownId INT 

ALTER TABLE Minions
ADD	CONSTRAINT FK_MinionsTowns FOREIGN KEY (TownId) REFERENCES Towns(Id)
