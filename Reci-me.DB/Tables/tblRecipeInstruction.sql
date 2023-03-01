CREATE TABLE [dbo].[tblRecipeInstruction]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Recipe Id] UNIQUEIDENTIFIER NOT NULL, 
    [InstructionNum] INT NOT NULL, 
    [Instruction] VARCHAR(600) NOT NULL, 
    [ImagePath] VARCHAR(250) NULL
)
