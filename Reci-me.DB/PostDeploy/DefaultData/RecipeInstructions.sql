BEGIN
	INSERT INTO tblRecipeInstruction VALUES
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), 1, 'Preheat the oven to 300 degrees F - Wrap the tortillas in foil and place them on a baking sheet or pan', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), 2, 'Season the Shrimp - In a large bowl, combine the shrimp, blackening seasoning, and salt', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), 3, 'Warm the tortillas - Bake the foil-wrapped tortillas until they’re warmed through, about 10 minutes (if your tortillas are done before you finish the slaw and shrimp, turn off the oven, and leave the tortillas inside to stay warm until you are ready to assemble', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), 4, 'Make the cabbage slaw - In a large bowl, combine the cabbage, mayo, sugar, black pepper, and white vinegar', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), 5, 'Cook the shrimp - In a large nonstick skillet over medium-high heat, add in the oil. Once it’s hot, add the shrimp. Cook until the shrimp have slightly browned on the outside and they’ve cooked through turning pink throughout, flipping halfway through, 2-3 minutes per side', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), 6, 'Assemble the tortillas - Place the tortillas in a serving platter or plates. Divide the shrimp and slaw equally between the tortillas', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), 7, 'Garnish and serve - garnish and serve with cheese and cilantro', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Blackened Shrimp Tacos'), 8, 'Storage - Try to eat all assembled tacos that same day. If you have leftover shrimp or slaw, store in separate air-tight containers in the fridge for up to 2 days', 'ImagePath'),

		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), 1, 'Pat the steak dry - Pat the steak dry with paper towels and season it liberally with salt all over, let rest at room temperature for 30 minutes', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), 2, 'Heat the skillet - Heat a cast-iron or stainless-steel skillet large enough to hold the steak on the stove over medium-high heat until very hot and it just barely starts to smoke, about 3 minutes', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), 3, 'Pat the steak dry (again) and cook - pat the steak dry again with paper towels, add the steak, and cook, pressing down to make sure it gets good contact with the pan, until a nice sear starts to form, about 2 minutes; flip over and cook for 2 minutes more. Then if you want a more well done steak, reduce the heat to medium low and continue to cook, flipping over repeatedly each minute, until the steak is as cooked as you desire', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), 4, 'Baste with butter and herbs (optional) - If you want more flavor, add the butter and herbs to the pan during the last couple minutes of cooking and baste it with the butter.', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Steak on the Stovetop'), 5, 'Serve - Remove the steak from the pan and let rest for a couple of minutes before slicing. If desired, sprinkle with some sea salt. Serve.', 'ImagePath'),

		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), 1, 'Preheat oven to 400°. In a small saucepan, prepare rice according to package instructions. In a large skillet over medium heat, heat oil. Cook onion until soft, about 5 minutes. Stir in tomato paste and garlic and cook until fragrant, about 1 minute more. Add ground beef and cook, breaking up meat with a wooden spoon, until no longer pink, 6 minutes. Drain fat.', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), 2, 'Return beef mixture to skillet, then stir in cooked rice and diced tomatoes. Season with oregano, salt, and pepper. Let simmer until liquid has reduced slightly, about 5 minutes.', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), 3, 'Place peppers cut side-up in a 9"-x-13" baking dish and drizzle with oil. Spoon beef mixture into each pepper and top with Monterey jack, then cover baking dish with foil.', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), 4, 'Bake until peppers are tender, about 35 minutes. Uncover and bake until cheese is bubbly, 10 minutes more.', 'Image Path'),
		(NEWID(), dbo.fnRecipeID('Stuffed Peppers'), 5, 'Garnish with parsley before serving.', 'Image Path'),
		
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), 1, 'Heat oil in a skillet over medium-high heat. Cook and stir sausage in the hot skillet until browned and crumbly, about 5 minutes. Reduce heat to medium. Add diced celery and chopped onion. Cook until onions are translucent, 4-5 minutes. Add dry pasta; cook and stir for 2 minutes', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), 2, 'Stir in tomato paste until evenly distributed, 2-3 minutes. Pour in 3 cups broth; increase heat to high and bring to a boil. Stir in red pepper flakes, oregano, salt, and pepper. Reduce heat to medium and let simmer, stirring often, for about 5 minutes. Add more broth if needed.', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), 3, 'Place chopped chard in a bowl. Cover with cold water and rinse leaves; any grit will fall to the bottom of the bowl. Transfer chard to a colander to drain briefly; add to soup. Cook and stir until leaves wilt, 2-3 minutes.', 'ImagePath'),
		(NEWID(), dbo.fnRecipeID('Pasta Fazool'), 4, 'Stir in white beans; continue cooking and stirring until pasta is tender, 4-5 minutes. Remove from heat and stir in grated cheese. Served topped with additional grated cheese.', 'ImagePath')
END

