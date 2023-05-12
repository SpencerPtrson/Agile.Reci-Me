﻿BEGIN
	INSERT INTO tblRecipeIngredient VALUES
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Granulated Sugar'), 0.5, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Blackend Seasoning'), 2, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Shrimp'), 2, dbo.fnMeasuringID('Pound'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Salt'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Corn Tortilla'), 8, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Red Cabbage'), 2, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Mayonnaise'), 0.25, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Black Pepper'), 0.25, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('White Vinegar'), 0.5, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Vegetable Oil'), 1, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Mexican Queso Fresco'), 0.5, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Cilantro'), 0.5, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), dbo.fnIngredientID('Lime Wedge'), 2, dbo.fnMeasuringID('Whole'), 0),

		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), dbo.fnIngredientID('Ribeye Steak'), 1, dbo.fnMeasuringID('Pound'), 0),
		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), dbo.fnIngredientID('Kosher Salt'), null, dbo.fnMeasuringID('As Needed'), 0),
		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), dbo.fnIngredientID('Unsalted Butter'), 1, dbo.fnMeasuringID('Pound'), 1),
		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), dbo.fnIngredientID('Thyme'), null, dbo.fnMeasuringID('Sprig'), 1),
		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), dbo.fnIngredientID('Flaky Sea Salt'), null, dbo.fnMeasuringID('As Needed'), 1),

		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Uncooked Rice'), 0.5, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Extra-Virgin Olive Oil'), 2, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Onion'), 1, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Tomato Paste'), 2, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Garlic'), 3, dbo.fnMeasuringID('Clove'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Ground Beef'), 1, dbo.fnMeasuringID('Pound'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Diced Tomatoes'), 1, dbo.fnMeasuringID('Can'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Dried Oregano'), 1.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Kosher Salt'), null, dbo.fnMeasuringID('As Needed'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Black Pepper'), null, dbo.fnMeasuringID('As Needed'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Bell Pepper'), 6, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Monterey Jack'), 1, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), dbo.fnIngredientID('Parsley'), null, dbo.fnMeasuringID('As Needed'), 1),

		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Olive Oil'), 1, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Italian Sausage'), 12, dbo.fnMeasuringID('Ounce'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Celery'), 1, dbo.fnMeasuringID('Stalk'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Yellow Onion'), 0.5, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Dry Elbow Macaroni'), 0.75, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Tomato Paste'), 0.25, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Chicken Broth'), 3, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Red Pepper Flakes'), 0.25, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Dried Oregano'), 0.25, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Black Pepper'), null, dbo.fnMeasuringID('As Needed'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Swiss Chard'), 3, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('White Kidney Beans'), 3, dbo.fnMeasuringID('Can'), 0),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), dbo.fnIngredientID('Parmigiano-Reggiano Cheese'), 0.25, dbo.fnMeasuringID('Cup'), 0),

		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Olive Oil'), 2, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Whole Chicken'), 1, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Onion'), 1, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Mushrooms'), 1, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Salt'), 1, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Black Pepper'), 1, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Garlic'), 4, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Rosemary'), 1, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Oregano'), 1, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Red Pepper Flakes'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Red Bell Pepper'), 2, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Chicken Cacciatore'), dbo.fnIngredientID('Green Bell Pepper'), 2, dbo.fnMeasuringID('Whole'), 0),
		
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Unsalted Butter'), 2, dbo.fnMeasuringID('Tablespoons'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Olive Oil'), 1, dbo.fnMeasuringID('Tablespoons'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Onion'), 1, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Celery'), 0.5, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Carrot'), 0.5, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Salt'), 1.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Ground Beef'), 1.5, dbo.fnMeasuringID('Pound'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Nutmeg'), 0.125, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Cayenne Pepper'), 0.125, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Black Pepper'), 0.125, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Milk'), 1.5, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('White Wine'), 2, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Bolognese Sauce'), dbo.fnIngredientID('Water'), 2, dbo.fnMeasuringID('Cup'), 0),

		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Ground Beef'), 1.5, dbo.fnMeasuringID('Pound'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Italian Sausage'), 1, dbo.fnMeasuringID('Pound'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Mushrooms'), 1, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Salt'), 1, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Black Pepper'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Italian Seasoning'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Red Pepper Flakes'), 0.25, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Marinara Sauce'), 6, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Water'), 0.25, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Lasagna Noodles'), 1, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Ricotta Cheese'), 3, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Lasagna'), dbo.fnIngredientID('Mozzarella Cheese'), 0.5, dbo.fnMeasuringID('Cup'), 0),

		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Pork Tenderloin'), 1.25, dbo.fnMeasuringID('Pound'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Black Pepper'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Salt'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Sage'), 12, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Prosciutto'), 4, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Flour'), 2, dbo.fnMeasuringID('Teaspoons'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Olive Oil'), 2, dbo.fnMeasuringID('Tablespoons'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('White Wine'), 0.6, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Unsalted Butter'), 1, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Chicken Broth'), 1, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Water'), 0.5, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Pork Saltimbocca'), dbo.fnIngredientID('Gelatin'), 1, dbo.fnMeasuringID('Teaspoon'), 0),

		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Sirloin Steak'), 2, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Break Crumbs'), 0.5, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Garlic'), 2, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Olive Oil'), 2, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Raisins'), 3, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Parmesan Cheese'), 0.3, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Salt'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Black Pepper'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Oregano'), 1, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Egg'), 1, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Olive Oil'), 1, dbo.fnMeasuringID('Tablespoon'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Water'), 1, dbo.fnMeasuringID('Cup'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Red Pepper Flakes'), 0.5, dbo.fnMeasuringID('Teaspoon'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Bay Leaf'), 1, dbo.fnMeasuringID('Whole'), 0),
		(NEWID(), dbo.fnRecipeID('Beef Braciole'), dbo.fnIngredientID('Tamoato Sauce'), 1.5, dbo.fnMeasuringID('Cup'), 0)
END