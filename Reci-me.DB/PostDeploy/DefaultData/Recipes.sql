BEGIN
	INSERT INTO dbo.tblRecipe (Id, Name, Servings, PrepTime, TotalTime, UserId, IsHidden, MainImagePath, CategoryId) VALUES
		(NEWID(), 'Blackened Shrimp Tacos', 4, 15.00, 31.00, 
		dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Shrimp Taco Image Path', dbo.fnCategoryID('Mexican')),
		
		(NEWID(), 'Steak on the Stovetop', 2, 30.00, 40.00, 
		dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Steak Image Path', dbo.fnCategoryID('American')),
		
		(NEWID(), 'Stuffed Peppers', 6, 10.00, 80.00, 
		dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Stuffed Pepper Image Path', dbo.fnCategoryID('Mexican')),
		
		(NEWID(), 'Pasta Fazool', 2, 10.00, 35.00, 
		dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Pasta Fazool Image Path', dbo.fnCategoryID('Italian'))	
END
