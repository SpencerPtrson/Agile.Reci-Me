
BEGIN
	INSERT INTO tblUser VALUES
		(NEWID(),'spencer.peterson0728@fvtc.edu', 'Agile', 'imagePath', 'ProfileDescription', dbo.fnAccessId('Admin')),
		(NEWID(),'byron.baker5104@fvtc.edu', 'Agile', 'imagePath', 'ProfileDescription', dbo.fnAccessId('Admin')),
		(NEWID(),'abigail.proudlock0180@fvtc.edu', 'Agile', 'imagePath', 'ProfileDescription', dbo.fnAccessId('Admin')),
		(NEWID(),'maxwell.wilke3555@fvtc.edu', 'Agile', 'imagePath', 'ProfileDescription', dbo.fnAccessId('Admin')),
		(NEWID(),'john.yang9556@fvtc.edu', 'Agile', 'imagePath', 'ProfileDescription', dbo.fnAccessId('Admin'))
END