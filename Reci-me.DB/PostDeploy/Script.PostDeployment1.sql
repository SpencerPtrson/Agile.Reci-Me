﻿/*
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

:r .\DefaultData\Users.sql
:r .\DefaultData\AccessLevels.sql
:r .\DefaultData\Recipes.sql
:r .\DefaultData\RecipeImages.sql
:r .\DefaultData\Ingredients.sql
:r .\DefaultData\MeasuringTypes.sql
:r .\DefaultData\Recipe-Ingredients.sql

