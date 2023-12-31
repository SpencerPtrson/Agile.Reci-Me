﻿CREATE TABLE [dbo].[tblRecipeIngredient]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [RecipeId] UNIQUEIDENTIFIER NOT NULL, 
    [IngredientId] UNIQUEIDENTIFIER NOT NULL, 
    [Quantity] FLOAT NULL, 
    [MeasuringId] UNIQUEIDENTIFIER NOT NULL, 
    [IsOptional] BIT NOT NULL
)

