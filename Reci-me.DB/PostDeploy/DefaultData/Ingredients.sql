BEGIN
	INSERT INTO tblIngredient VALUES
		/* Seafood */
		(NEWID(),'Shrimp', 1),

		/* Meats */
		(NEWID(),'Ribeye Steak', 0),
		(NEWID(),'Steak Strip', 0),
		(NEWID(),'Porterhouse', 0),
		(NEWID(),'Pork Tenderloin', 0),
		(NEWID(),'Prosciutto', 0),
		(NEWID(),'Italian Sausage', 0),
		(NEWID(),'Ground Beef', 0),
		(NEWID(), 'Whole Chicken', 0),
		(NEWID(), 'Sirloin Steak', 0),
		
		/* Salts */
		(NEWID(),'Salt', 0),
		(NEWID(),'Flaky Sea Salt', 0),
		(NEWID(),'Kosher Salt', 0),
		
		/* Seasonings */
		(NEWID(),'Blackend Seasoning', 0),
		(NEWID(),'Parsley', 0),
		(NEWID(),'Thyme', 0),
		(NEWID(),'Italian Seasoning', 0),
		(NEWID(),'Nutmeg', 0),
		(NEWID(),'Bay Leaf', 0),
		(NEWID(),'Sage', 0),
		(NEWID(),'Rosemary', 0),
		(NEWID(),'Black Pepper', 0),
		(NEWID(),'Garlic', 0),
		(NEWID(),'Cayenne Pepper', 0),
		(NEWID(),'Oregano', 0),
		(NEWID(),'Dried Oregano', 0),
		(NEWID(),'Cilantro', 0),
		(NEWID(),'White Vinegar', 0), /* According to google */
		
		/* Vegetables */
		(NEWID(),'Red Cabbage', 0),
		(NEWID(),'Onion', 0),
		(NEWID(),'Yellow Onion', 0),
		(NEWID(),'Swiss Chard', 0),
		(NEWID(),'Bell Pepper' ,0),
		(NEWID(),'Black Pepper', 0),
		(NEWID(),'Celery', 0),
		(NEWID(),'Carrot', 0),
		(NEWID(),'Red Pepper Flakes', 0),
		(NEWID(),'Tomato Paste', 0),
		(NEWID(),'Diced Tomatoes', 0),
		(NEWID(),'Plum Tomatoes', 0),
		(NEWID(),'White Kidney Beans', 0),
		(NEWID(),'Mushrooms', 0),
		(NEWID(),'Red Bell Peppers', 0),
		(NEWID(),'Green Bell Peppers', 0),
		
		/* Fruit */
		(NEWID(),'Lime Wedge', 0),
		(NEWID(),'Raisins', 0),
		
		/* Cheeses */
		(NEWID(),'Monterey Jack', 0),
		(NEWID(),'Mexican Queso Fresco', 0),
		(NEWID(),'Parmigiano-Reggiano Cheese', 0),
		
		/* Oils */
		(NEWID(),'Vegetable Oil', 0),
		(NEWID(),'Extra-Virgin Olive Oil', 0),
		(NEWID(),'Olive Oil', 0),
		(NEWID(),'Mayonnaise', 0), /* According to google */
		
		/* Sweets */
		(NEWID(),'Granulated Sugar', 0),
		
		/* Dairy */
		(NEWID(),'Unsalted Butter', 0),
		(NEWID(),'Ricotta Cheese', 0),
		(NEWID(),'Egg', 0),
		(NEWID(),'Parmesan Cheese', 0),
		(NEWID(),'Mozzarella Cheese', 0),
		
		/* Grains */
		(NEWID(),'Corn Tortilla', 0),
		(NEWID(),'Dry Elbow Macaroni', 0),
		(NEWID(),'Uncooked Rice', 0),
		(NEWID(),'Flour', 0),
		
		/* Soups / Sauces / Gravies */
		(NEWID(),'Chicken Broth', 0),
		(NEWID(),'Marinara Sauce', 0),
		(NEWID(),'Tomoato Sauce', 0),

		/* Pasta */
		(NEWID(), 'Lasagna Noodles', 0),

		/* Other */
		(NEWID(), 'Water', 0),
		(NEWID(), 'White Wine', 0),
		(NEWID(), 'Gelatin', 0),
		(NEWID(), 'Bread Crumbs', 0)
END