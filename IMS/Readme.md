#Readme

TODOS
--2021-11-06 
--done remove Name column from DepartmentUser table
--done remove VendorId column from DepartmentUser table
--done change nullable userId to non-nullable from DepartmentUser table
--done remove createdAt and deletedAt from ManufactureDepartmentUserModel
--done make non null of UserId in DepartmentUser table
--done add BuildRate in DepartmentUser table

make decimal(9,2) in DepartmentUser 's BuildRate. 
all BuildRate in all table should be decimal(9,2). not (9,4)
make non-null of quantity in manufactureproduct

add date in UserManufactureProduct table 
remove packageId from UserManufactureProduct table ; will use packageId from ManufactureDepartmentProduct table
remove ProposedOrProduction from ManufactureProducts; it will always be Proposed
remove ProposedOrProduction from ManufactureDepartmentProducts; it will always be Proposed

