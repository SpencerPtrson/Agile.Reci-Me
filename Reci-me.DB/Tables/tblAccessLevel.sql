CREATE TABLE [dbo].[tblAccessLevel]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Permissions] INT NOT NULL
)
