BEGIN
	INSERT INTO tblAccessLevel VALUES
		(NEWID(),'Admin','Read,Write'),
		(NEWID(),'User','Read')
END