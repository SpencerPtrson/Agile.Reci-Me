BEGIN
	INSERT INTO [dbo].[tblAccessLevel] ([Id], [Description], [Label], [Permissions]) VALUES (N'9f0f402e-4edc-4310-bb80-5eb45a6948f2', N'Admin', N'Master Chef', 0)
	INSERT INTO [dbo].[tblAccessLevel] ([Id], [Description], [Label], [Permissions]) VALUES (N'a545aa96-220b-4d63-84ec-df48998ed7d5', N'User', N'Homecook', 1)
	INSERT INTO [dbo].[tblAccessLevel] ([Id], [Description], [Label], [Permissions]) VALUES (N'ba31fcd6-01c0-4edf-ab3b-fa8eeb3c8edc', N'Moderator', N'Sous Chef', 0)
END