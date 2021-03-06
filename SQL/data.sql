USE [Raunstrup]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [Name], [StreetName], [StreetNumber], [City], [PostalCode]) VALUES (1, N'Tobias', N'Boulevarden', N'27', N'Vejle', N'7100')
INSERT [dbo].[Customer] ([CustomerId], [Name], [StreetName], [StreetNumber], [City], [PostalCode]) VALUES (2, N'Per Olesen', N'Boulevarden', N'11', N'Fredericia', N'7000')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [Name]) VALUES (1, N'Kaj')
INSERT [dbo].[Employee] ([EmployeeId], [Name]) VALUES (2, N'Emilie')
INSERT [dbo].[Employee] ([EmployeeId], [Name]) VALUES (3, N'Simone')
INSERT [dbo].[Employee] ([EmployeeId], [Name]) VALUES (4, N'Ole Persen')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Draft] ON 

INSERT [dbo].[Draft] ([DraftId], [WorkTitle], [Description], [CreationDate], [StartDate], [EndDate], [Discount], [IsOffer], [CustomerId], [ResponsibleEmployeeId]) VALUES (1, N'Tobias'' nye kælder', N'Kælder til diverse ting', CAST(N'2015-12-16' AS Date), CAST(N'2015-12-17' AS Date), CAST(N'2016-01-13' AS Date), 10, 1, 1, 3)
INSERT [dbo].[Draft] ([DraftId], [WorkTitle], [Description], [CreationDate], [StartDate], [EndDate], [Discount], [IsOffer], [CustomerId], [ResponsibleEmployeeId]) VALUES (2, N'Ny garagetilbygning', N'Ny tilbygning til garage med port', CAST(N'2015-12-16' AS Date), CAST(N'2015-12-18' AS Date), CAST(N'2015-12-22' AS Date), 0, 1, 1, 3)
INSERT [dbo].[Draft] ([DraftId], [WorkTitle], [Description], [CreationDate], [StartDate], [EndDate], [Discount], [IsOffer], [CustomerId], [ResponsibleEmployeeId]) VALUES (3, N'Retning af rapport', N'Ole skal hjælpe Per med at rette rapporter', CAST(N'2015-12-18' AS Date), CAST(N'2015-12-20' AS Date), CAST(N'2015-12-31' AS Date), 20, 1, 2, 4)
SET IDENTITY_INSERT [dbo].[Draft] OFF
SET IDENTITY_INSERT [dbo].[Skill] ON 

INSERT [dbo].[Skill] ([SkillId], [Name]) VALUES (1, N'Sekretær')
INSERT [dbo].[Skill] ([SkillId], [Name]) VALUES (2, N'Gulv')
INSERT [dbo].[Skill] ([SkillId], [Name]) VALUES (3, N'Tag')
INSERT [dbo].[Skill] ([SkillId], [Name]) VALUES (4, N'Mahogany')
SET IDENTITY_INSERT [dbo].[Skill] OFF
INSERT [dbo].[EmployeeSkill] ([EmployeeId], [SkillId]) VALUES (1, 2)
INSERT [dbo].[EmployeeSkill] ([EmployeeId], [SkillId]) VALUES (2, 2)
INSERT [dbo].[EmployeeSkill] ([EmployeeId], [SkillId]) VALUES (2, 3)
INSERT [dbo].[EmployeeSkill] ([EmployeeId], [SkillId]) VALUES (3, 1)
INSERT [dbo].[EmployeeSkill] ([EmployeeId], [SkillId]) VALUES (4, 4)
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectId], [OrderDate], [DraftId]) VALUES (1, CAST(N'2015-12-16' AS Date), 2)
INSERT [dbo].[Project] ([ProjectId], [OrderDate], [DraftId]) VALUES (2, CAST(N'2015-12-18' AS Date), 3)
SET IDENTITY_INSERT [dbo].[Project] OFF
INSERT [dbo].[ProjectEmployee] ([ProjectId], [EmployeeId]) VALUES (1, 1)
INSERT [dbo].[ProjectEmployee] ([ProjectId], [EmployeeId]) VALUES (1, 2)
INSERT [dbo].[ProjectEmployee] ([ProjectId], [EmployeeId]) VALUES (2, 4)
SET IDENTITY_INSERT [dbo].[Report] ON 

INSERT [dbo].[Report] ([ReportId], [Date], [ProjectId], [EmployeeId]) VALUES (3, CAST(N'2015-12-17' AS Date), 1, 1)
INSERT [dbo].[Report] ([ReportId], [Date], [ProjectId], [EmployeeId]) VALUES (4, CAST(N'2015-12-17' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[Report] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [Name], [SalesPrice]) VALUES (1, N'Gulvbrædde', CAST(110.00 AS Decimal(9, 2)))
INSERT [dbo].[Product] ([ProductId], [Name], [SalesPrice]) VALUES (2, N'Håndværkertime', CAST(155.00 AS Decimal(9, 2)))
INSERT [dbo].[Product] ([ProductId], [Name], [SalesPrice]) VALUES (3, N'Opel pr. km', CAST(1.15 AS Decimal(9, 2)))
INSERT [dbo].[Product] ([ProductId], [Name], [SalesPrice]) VALUES (4, N'Mahogany', CAST(180.00 AS Decimal(9, 2)))
INSERT [dbo].[Product] ([ProductId], [Name], [SalesPrice]) VALUES (5, N'Murer', CAST(140.00 AS Decimal(9, 2)))
INSERT [dbo].[Product] ([ProductId], [Name], [SalesPrice]) VALUES (6, N'VW pr. dag', CAST(110.00 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[OrderLine] ON 

INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (1, 5, CAST(155.00 AS Decimal(9, 2)), 1, 2)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (2, 100, CAST(110.00 AS Decimal(9, 2)), 1, 1)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (3, 10, CAST(155.00 AS Decimal(9, 2)), 2, 2)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (4, 50, CAST(100.00 AS Decimal(9, 2)), 2, 1)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (5, 20, CAST(1.15 AS Decimal(9, 2)), 2, 3)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (6, 251, CAST(110.00 AS Decimal(9, 2)), 2, 1)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (12, 10, CAST(155.00 AS Decimal(9, 2)), 3, 2)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (13, 10, CAST(140.00 AS Decimal(9, 2)), 3, 5)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (14, 100, CAST(110.00 AS Decimal(9, 2)), 3, 1)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (15, 100, CAST(180.00 AS Decimal(9, 2)), 3, 4)
INSERT [dbo].[OrderLine] ([OrderLineId], [Quantity], [PricePerUnit], [DraftId], [ProductId]) VALUES (16, 3, CAST(110.00 AS Decimal(9, 2)), 3, 6)
SET IDENTITY_INSERT [dbo].[OrderLine] OFF
INSERT [dbo].[Material] ([MaterialId], [CostPrice]) VALUES (1, CAST(55.00 AS Decimal(9, 2)))
INSERT [dbo].[Material] ([MaterialId], [CostPrice]) VALUES (4, CAST(105.00 AS Decimal(9, 2)))
INSERT [dbo].[WorkHour] ([WorkHourId]) VALUES (2)
INSERT [dbo].[WorkHour] ([WorkHourId]) VALUES (5)
INSERT [dbo].[Transport] ([TransportId]) VALUES (3)
INSERT [dbo].[Transport] ([TransportId]) VALUES (6)
SET IDENTITY_INSERT [dbo].[ReportLine] ON 

INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (11, 4, 3, 2)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (12, 3, 3, 3)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (13, 50, 3, 1)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (14, 30, 3, 1)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (15, 20, 3, 1)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (16, 4, 4, 2)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (17, 3, 4, 3)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (18, 50, 4, 1)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (19, 30, 4, 1)
INSERT [dbo].[ReportLine] ([ReportLineId], [Quantity], [ReportId], [ProductId]) VALUES (20, 20, 4, 1)
SET IDENTITY_INSERT [dbo].[ReportLine] OFF
