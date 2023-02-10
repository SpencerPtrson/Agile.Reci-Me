CREATE TABLE [dbo].[tblRecipe]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Servings] INT NOT NULL, 
    [Instructions] VARCHAR(900) NOT NULL, 
    [TotalTime] FLOAT NOT NULL, 
    [PrepTime] FLOAT NOT NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [IsHidden] BIT NOT NULL
)
