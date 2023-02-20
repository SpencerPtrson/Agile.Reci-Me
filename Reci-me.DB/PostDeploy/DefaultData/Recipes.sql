BEGIN
	INSERT INTO tblRecipe VALUES
		(NEWID(), 'Blackened Shrimp Tacos', 4, 15.00, 
		31.00, dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Shrimp Taco Image Path'),
		
		(NEWID(), 'Steak on the Stovetop', 2, 30.00, 
		40.00, dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Steak Image Path'),
		
		(NEWID(), 'Stuffed Peppers', 6, 10.00, 
		80.00, dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Stuffed Pepper Image Path'),
		
		(NEWID(), 'Pasta Fazool', 2, 10.00, 
		35.00, dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Pasta Fazool Image Path')	
END
