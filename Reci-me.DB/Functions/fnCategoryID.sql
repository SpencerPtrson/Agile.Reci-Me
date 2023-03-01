﻿GO
CREATE FUNCTION fnCategoryID (@Category VARCHAR(50))
	RETURNS UNIQUEIDENTIFIER AS BEGIN
		RETURN (SELECT Id FROM tblRecipeCategory WHERE @Category = Category)
END