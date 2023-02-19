
BEGIN
	INSERT INTO tblUser VALUES
		(NEWID(),'spencer.peterson0728@fvtc.edu', 'IWAJFB6EU77UKDaXsjhIMMHsIwA=', 'Toy.jpg', 'Hi name is Spencer', dbo.fnAccessId('Admin')),
		(NEWID(),'byron.baker5104@fvtc.edu', 'IWAJFB6EU77UKDaXsjhIMMHsIwA=', 'Toy.jpg', 'Hi my name is Byron', dbo.fnAccessId('Admin')),
		(NEWID(),'abigail.proudlock0180@fvtc.edu', 'IWAJFB6EU77UKDaXsjhIMMHsIwA=', 'Toy.jpg', 'Hi my name is Abbie', dbo.fnAccessId('Admin')),
		(NEWID(),'maxwell.wilke3555@fvtc.edu', 'IWAJFB6EU77UKDaXsjhIMMHsIwA=', 'Bond.jpg', 'Hi my name is Max', dbo.fnAccessId('Admin')),
		(NEWID(),'john.yang9556@fvtc.edu', 'IWAJFB6EU77UKDaXsjhIMMHsIwA=', 'Toy.jpg', 'Hi my name is John', dbo.fnAccessId('Admin'))
END