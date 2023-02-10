﻿CREATE FUNCTION UserID (@Email VARCHAR(50))
	RETURNS UNIQUEIDENTIFIER AS BEGIN
		RETURN (SELECT Id FROM tblUser WHERE Email = @Email)
END