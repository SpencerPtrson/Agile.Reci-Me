BEGIN
	INSERT INTO tblAccessLevel VALUES
		(NEWID(),'Admin','Master Chef', 0),
		(NEWID(),'Moderator','Sous Chef', 0),
		(NEWID(),'User','Homecook', 1)
END