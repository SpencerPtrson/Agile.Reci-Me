CREATE TABLE [dbo].[tblIngredient]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [IsCommonAllergen] BIT NOT NULL
)
