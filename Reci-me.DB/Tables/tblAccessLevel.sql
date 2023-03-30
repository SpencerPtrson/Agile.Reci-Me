CREATE TABLE [dbo].[tblAccessLevel]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(50) NOT NULL, 
    [Label] VARCHAR(50) NOT NULL,
    [Permissions] INT NOT NULL
)
