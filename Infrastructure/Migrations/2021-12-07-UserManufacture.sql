-- 2021-12-07 -- add PackageId column in UserManufacture.
alter table UserManufactures add PackageId int null constraint FK_UserManufactureProducts_Packages_PackageId foreign key references Packages(Id)
GO
update um
set PackageId = (select top 1 PackageId from ProductPackages where ProductId = um.ProductId and IsBasePackage = 1)
from UserManufactures um
inner join Products p on um.ProductId = p.Id
GO
alter table UserManufactures alter column PackageId int not null