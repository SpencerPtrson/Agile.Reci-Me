﻿CREATE FUNCTION fnIngredientID (@Name VARCHAR(50))
	RETURNS UNIQUEIDENTIFIER AS BEGIN
		RETURN (SELECT Id FROM tblIngredient WHERE Name = @Name)
END