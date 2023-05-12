BEGIN
	INSERT INTO dbo.tblRecipe (Id, Name, Servings, PrepTime, TotalTime, UserId, IsHidden, MainImagePath, CategoryId) VALUES
		(NEWID(), 'Blackened Shrimp Tacos', 4, 15.00, 31.00, 
		dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'blackenedshrimptacos.jpg', dbo.fnCategoryID('Mexican')),
		
		(NEWID(), 'Steak on the Stovetop', 2, 30.00, 40.00, 
		dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'steakonstove.jpg', dbo.fnCategoryID('American')),
		
		(NEWID(), 'Stuffed Peppers', 6, 10.00, 80.00, 
		dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'stuffedpeppers.jpg', dbo.fnCategoryID('Mexican')),
		
		(NEWID(), 'Pasta Fazool', 2, 10.00, 35.00, 
		dbo.fnUserID('spencer.peterson0728@fvtc.edu'), 0, 'Pasta-Fazool.jpg', dbo.fnCategoryID('Italian')),

		(NEWID(), 'Chicken Cacciatore', 6, 20.00, 110.00, 
		dbo.fnUserID('abigail.proudlock0180@fvtc.edu'), 0, 'chickenCacciatore.jpg', dbo.fnCategoryID('Italian')),

		(NEWID(), 'Bolognese Sauce', 6, 15.00, 215.00, 
		dbo.fnUserID('abigail.proudlock0180@fvtc.edu'), 0, 'bolognese.jpg', dbo.fnCategoryID('Italian')),

		(NEWID(), 'Lasagna', 12, 25.00, 195.00, 
		dbo.fnUserID('abigail.proudlock0180@fvtc.edu'), 0, 'lasagna.jpg', dbo.fnCategoryID('Italian')),

		(NEWID(), 'Pork Saltimbocca', 2, 20.00, 105.00, 
		dbo.fnUserID('abigail.proudlock0180@fvtc.edu'), 0, 'porkSaltimbocca.jpg', dbo.fnCategoryID('Italian')),

		(NEWID(), 'Beef Braciole', 4, 20.00, 55.00, 
		dbo.fnUserID('abigail.proudlock0180@fvtc.edu'), 0, 'beefBraciole.jpg', dbo.fnCategoryID('Italian'))
END
