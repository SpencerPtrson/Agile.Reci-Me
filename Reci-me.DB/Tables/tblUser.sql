CREATE TABLE [dbo].[tblUser]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Email] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [Picture] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(400) NOT NULL, 
    [AccessLevelId] UNIQUEIDENTIFIER NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL
)
