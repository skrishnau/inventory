/*
--all  drop queries
drop table UserManufactureProducts
drop table UserManufactures
drop table ManufactureDepartmentProducts
drop table ManufactureDepartmentUsers
drop table ManufactureDepartments
drop table ManufactureProducts
drop table Manufactures
drop table UserProductHistories
drop table UserProducts
drop table DepartmentUsers
drop table Departments
*/



-- Manufacture create table queries
create table Departments (
	Id int not null primary key identity(1,1),
	Name nvarchar(150) not null,
	Description nvarchar(256) null,
	IsVendor bit not null default (0),
	HeadUserId int null constraint FK_Departments_Users_HeadUserId foreign key references Users(Id),
	DeletedAt datetime null
);
--departmentusers ra manufacturedepartmentusers ko same data hunu parxa.. userproducthistory baaki
create table DepartmentUsers(
	Id int not null primary key identity(1,1),
	DepartmentId int not null constraint FK_DepartmentUsers_Departments_DepartmentId foreign key references Departments(Id),
	UserId int null constraint FK_DepartmentUsers_Users_UserId foreign key references Users(Id),
	DeletedAt datetime null,
);
create table UserProducts (
	Id int not null primary key identity(1,1),
	UserId int not null constraint FK_UserProducts_Users_UserId foreign key references Users(Id),
	ProductId int not null constraint FK_UserProducts_Products_ProductId foreign key references Products(Id),
	PackageId int not null constraint FK_UserProducts_Packages_PackageId foreign key references Packages(Id),
	Quantity decimal (18,2) not null,
	UpdatedAt datetime not null
);
create table UserProductHistories(
	Id int not null primary key identity(1,1),
	UserId int not null constraint FK_UserProductHistories_Users_UserId foreign key references Users(Id),
	ProductId int not null constraint FK_UserProductHistories_Products_ProductId foreign key references Products(Id),
	PackageId int not null constraint FK_UserProductHistories_Packages_PackageId foreign key references Packages(Id),
	Quantity decimal (18,9) not null,
	FromToUserId int null constraint FK_UserProductHistories_Users_FromUserId foreign key references Users(Id),
	InOut bit not null, -- in=1 , out=0
	Remarks nvarchar(256) null,
	UpdatedAt datetime not null
);

create table Manufactures(
	Id int not null primary key identity(1,1),
	Name nvarchar(250) not null,
	LotNo int not null,
	Remarks nvarchar(250) null,
	CreatedAt datetime null,
	CreatedByUserId int null constraint FK_Manufactures_Users_CreatedByUserId foreign key references Users(Id),
	DeletedAt datetime null,
	DeletedByUserId int null constraint FK_Manufactures_Users_DeletedByUserId foreign key references Users(Id),
	StartedAt datetime null,
	StartedByUserId int null constraint FK_Manufactures_Users_StartedByUserId foreign key references Users(Id),
	CompletedAt datetime null,
	CompletedByUserId int null constraint FK_Manufactures_Users_CompletedByUserId foreign key references Users(Id),
	CancelledAt datetime null,
	CancelledByUserId int null constraint FK_Manufactures_Users_CancelledByUserId foreign key references Users(Id)
);

-- Final Manufactured Product's rate quantity pkg
create table ManufactureProducts(
	Id int not null primary key identity(1,1),
	ManufactureId int not null constraint FK_ManufactureProducts_Manufatures_ManufactureId foreign key references Manufactures(Id),
	ProposedOrProduction bit not null default (0), -- Proposed=0, Prodution=1
	ProductId int not null constraint FK_ManufactureProducts_Products_ProductId foreign key references Products(Id),
	Quantity decimal (18,2),
	PackageId int not null constraint FK_ManufactureProducts_Packages_PackageId foreign key references Packages(Id),
	InOut bit not null,
	CostRate decimal (11,4) null, -- including cost of raw materials
	BuildRate decimal (11,4) null -- cost of building a final product
);
create table ManufactureDepartments(
	Id int not null primary key identity(1,1),
	ManufactureId int not null constraint FK_ManufactureDepartments_Manufactures_ManufactureId foreign key references Manufactures(Id),
	DepartmentId int not null constraint FK_ManufactureDepartments_Departments_DepartmentId foreign key references Departments(Id),
	Name nvarchar(150) not null, -- Department Name
	IsVendor bit not null default (0), -- Department IsVendor
	HeadUserId int null constraint FK_ManufactureDepartments_Users_UserId foreign key references Users(Id), -- Department HeadUserId
	Position int not null, 
	-- Workflow related
	StartedAt datetime null,
	StartedByUserId int null constraint FK_ManufactureDepartments_Users_StartedByUserId foreign key references Users(Id),
	CompletedAt datetime null,
	CompletedByUserId int null constraint FK_ManufactureDepartments_Users_CompletedByUserId foreign key references Users(Id),
	CancelledAt datetime null,
	CancelledByUserId int null constraint FK_ManufactureDepartments_Users_CancelledByUserId foreign key references Users(Id),
	Remarks nvarchar(250) null,
);
create table ManufactureDepartmentUsers(
	Id int not null primary key identity(1,1),
	ManufactureDepartmentId int not null constraint FK_ManufactureDepartmentUsers_ManufactureDepartments_ManufactureDepartmentId foreign key references ManufactureDepartments(Id),
	UserId int not null constraint FK_ManufactureDepartmentUsers_Users_UserId foreign key references Users(Id),
	CreatedAt datetime null,
	DeletedAt datetime null,
	BuildRate decimal (11,4) null,
);
create table ManufactureDepartmentProducts(
	Id int not null primary key identity(1,1),
	ManufactureDepartmentId int not null constraint FK_ManufactureDepartmentProducts_ManufactureDepartments_ManufactureDepartmentId foreign key references ManufactureDepartments(Id),
	ProposedOrProduction bit not null default (0), -- Proposed=0, Prodution=1
	ProductId int not null constraint FK_ManufactureDepartmentProducts_Products_ProductId foreign key references Products(Id),
	PackageId int not null constraint FK_ManufactureDepartmentProducts_Packages_PackageId foreign key references Packages(Id),
	Quantity decimal (18,2) not null,
	InOut bit not null,
	BuildRate decimal (11,4) null, -- total build rate; only in "Out" row
);
-- =====// Process //===== --
create table UserManufactures(
	Id int not null primary key identity(1,1),
	ManufactureDepartmentUserId int not null constraint FK_UserManufactures_ManufactureDepartmentUsers_ManufactureDepartmentUserId foreign key references ManufactureDepartmentUsers(Id),
	StartedAt DateTime null,
	CompletedAt DateTime null,
	CancelledAt Datetime null,
	BuildRate decimal (11,4) null,
	Remarks nvarchar(250) null,
);
create table UserManufactureProducts(
	Id int not null primary key identity(1,1),
	UserManufactureId int not null constraint FK_UserManufactureProducts_UserManufactures_UserProductManufactureId foreign key references UserManufactures(Id),
	ProductId int not null constraint FK_UserManufactureProducts_Products_ProductId foreign key references Products(Id),
	PackageId int not null constraint FK_UserManufactureProducts_Packages_PackageId foreign key references Packages(Id),
	Quantity decimal (18,2) not null,
	InOut bit not null, -- Consume or Build or Damage 
);

/*
-- NOT to be used but for reference only

/*
create table Company (
	Id int not null primary key identity(1,1),
	Name nvarchar(256) not null,
	Address nvarchar(256) null,
	VATNo nvarchar(50) null,
	PANNo nvarchar(50) null,
	Phone nvarchar(50) null,
	Email nvarchar(100) null,
	Website nvarchar(100) null,
	Currency nvarchar(30) null,
	CurrencySymbol nvarchar(5) null,
);
*/

--create table Chains (
--	Id int not null primary key identity(1,1),
--	Name nvarchar(150) not null,
--	Description nvarchar(256) null,
--	DeletedAt datetime null
--)
--create table ChainDepartments (
--	Id int not null primary key identity(1,1),
--	ChainId int not null constraint FK_ChainDepartments_Chains_ChainId foreign key references Chains(Id),
--	DepartmentId int not null constraint FK_ChainDepartments_Departments_DepartmentId foreign key references Departments(Id),
--	Position int not null
--);

create table UserManufactures(
	Id int not null primary key identity(1,1),
	UserId int not null constraint FK_DepartmentUsers_Users_UserId foreign key references Users(Id),
	ManufactureId int not null constraint FK_DepartmentUsers_Users_UserId foreign key references Users(Id),
	DepartmentId int not null constraint FK_Workflows_Departments_DepartmentId foreign key references Departments(Id),
);
*/