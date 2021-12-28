-- 2021-12-10 
alter table InventoryUnits add AssignedToUserId int null constraint FK_InventoryUnits_Users_AssignedToUserId foreign key references Users(Id)
GO
alter table InventoryUnits add AssignedToDepartmentId int null constraint FK_InventoryUnits_Users_AssignedToDepartmentId foreign key references Departments(Id)


-- 2021-12-18
alter table OrderItems alter column OrderId int null