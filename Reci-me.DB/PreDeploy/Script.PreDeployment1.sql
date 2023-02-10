/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DROP TABLE IF EXISTS dbo.tblRecipeIngredient
DROP TABLE IF EXISTS dbo.tblRecipeImage
DROP TABLE IF EXISTS dbo.tblIngredient
DROP TABLE IF EXISTS dbo.tblRecipe
DROP TABLE IF EXISTS dbo.tblAccessLevel
DROP TABLE IF EXISTS dbo.tblUser
DROP TABLE IF EXISTS dbo.tblMeasuringType