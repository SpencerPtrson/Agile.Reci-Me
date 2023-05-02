/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\CurrentData\Categories.sql
:r .\CurrentData\AccessLevels.sql
:r .\CurrentData\Users.sql
:r .\CurrentData\Recipes.sql
:r .\CurrentData\RecipeInstructions.sql
:r .\CurrentData\Ingredients.sql
:r .\CurrentData\MeasuringTypes.sql
:r .\CurrentData\Recipe-Ingredients.sql

