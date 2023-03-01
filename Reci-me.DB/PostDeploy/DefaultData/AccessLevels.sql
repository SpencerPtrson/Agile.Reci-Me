BEGIN
	INSERT INTO tblAccessLevel VALUES
		(NEWID(),'Admin', 0),
		(NEWID(),'User', 1)
END