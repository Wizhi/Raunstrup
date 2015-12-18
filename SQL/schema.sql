IF OBJECT_ID('Customer', 'U') IS NULL
	CREATE TABLE Customer (
		CustomerId int primary key identity,
		Name varchar(100) not null,
		StreetName varchar(50) not null,
		StreetNumber varchar(5) not null,
		City varchar(50) not null,
		PostalCode varchar(4) not null
	);

IF OBJECT_ID('Employee', 'U') IS NULL
	CREATE TABLE Employee (
		EmployeeId int primary key identity,
		Name varchar(100) not null
	);

IF OBJECT_ID('Skill', 'U') IS NULL
	CREATE TABLE Skill (
		SkillId int primary key identity,
		Name varchar(100) not null
	);

IF OBJECT_ID('EmployeeSkill', 'U') IS NULL
	CREATE TABLE EmployeeSkill (
		EmployeeId int not null foreign key references Employee(EmployeeId),
		SkillId int not null foreign key references Skill(SkillId)
	);
	
IF OBJECT_ID('Draft', 'U') IS NULL
	CREATE TABLE Draft (
		DraftId int primary key identity,
		WorkTitle varchar(100) not null,
		[Description] varchar(MAX) not null,
		CreationDate date not null,
		StartDate date not null,
		EndDate date not null,
		Discount float not null,
		IsOffer bit not null default 0,
		CustomerId int not null foreign key references Customer(CustomerId),
		ResponsibleEmployeeId int not null foreign key references Employee(EmployeeId)
	);

IF OBJECT_ID('Skill', 'U') IS NULL
	CREATE TABLE Skill (
		SkillId int primary key identity,
		Name varchar(100) not null
	);

IF OBJECT_ID('EmployeeSkill', 'U') IS NULL
	CREATE TABLE EmployeeSkill (
		EmployeeId int not null foreign key references Employee(EmployeeId),
		SkillId int not null foreign key references Skill(SkillId)
	);

IF OBJECT_ID('Project', 'U') IS NULL
	CREATE TABLE Project (
		ProjectId int primary key identity,
		OrderDate date not null,
		DraftId int not null foreign key references Draft(DraftId)
	);

IF OBJECT_ID('ProjectEmployee', 'U') IS NULL
	CREATE TABLE ProjectEmployee (
		ProjectId int not null foreign key references Project(ProjectId),
		EmployeeId int not null foreign key references Employee(EmployeeId)
	);

IF OBJECT_ID('Product', 'U') IS NULL
BEGIN
	CREATE TABLE Product (
		ProductId int primary key identity,
		Name varchar(100) not null,
		SalesPrice decimal(9, 2) not null
	);

	CREATE TABLE Material (
		MaterialId int primary key references Product(ProductId),
		CostPrice decimal(9, 2) not null
	);

	CREATE TABLE WorkHour (
		WorkHourId int primary key references Product(ProductId)
	);

	CREATE TABLE Transport (
		TransportId int primary key references Product(ProductId)
	);
END

IF OBJECT_ID('OrderLine', 'U') IS NULL
	CREATE TABLE OrderLine (
		OrderLineId int primary key identity,
		Quantity int not null,
		PricePerUnit decimal(9, 2) not null,
		DraftId int not null foreign key references Draft(DraftId),
		ProductId int not null foreign key references Product(ProductId)
	);

IF OBJECT_ID('Report', 'U') IS NULL
	CREATE TABLE Report (
		ReportId int primary key identity,
		[Date] date not null,
		ProjectId int not null foreign key references Project(ProjectId),
		EmployeeId int not null foreign key references Employee(EmployeeId)
	);

IF OBJECT_ID('ReportLine', 'U') IS NULL
	CREATE TABLE ReportLine (
		ReportLineId int primary key identity,
		Quantity int not null,
		ReportId int not null foreign key references Report(ReportId),
		ProductId int not null foreign key references Product(ProductId)
	);

IF OBJECT_ID('AllProducts', 'V') IS NOT NULL
	DROP VIEW AllProducts;

GO

CREATE VIEW AllProducts
AS
SELECT
	p.*,
	p_m.*,
	p_w.*,
	p_t.*
FROM Product p
LEFT JOIN Material p_m ON p_m.MaterialId = p.ProductId
LEFT JOIN WorkHour p_w ON p_w.WorkHourId = p.ProductId
LEFT JOIN Transport p_t ON p_t.TransportId = p.ProductId;

GO

/*
DROP TABLE ReportLine
DROP TABLE Report
DROP TABLE OrderLine
DROP TABLE Material
DROP TABLE WorkHour
DROP TABLE Transport
DROP TABLE Product
DROP TABLE ProjectEmployee
DROP TABLE Project
DROP TABLE Draft
DROP TABLE EmployeeSkill
DROP TABLE Skill
DROP TABLE Employee
DROP TABLE Customer
*/