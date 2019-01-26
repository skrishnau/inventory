namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initwithproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategoryId = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategoryId)
                .Index(t => t.ParentCategoryId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        isSystemDefined = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Fax = c.String(),
                        Website = c.String(),
                        PhoneSecond = c.String(),
                        ContactPersonName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        QuantityInStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitCostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LatestUnitSellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShowStockAlerts = c.Boolean(nullable: false),
                        MinStockCountForAlert = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Code = c.String(),
                        CanMoveStocksToBranch = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .Index(t => t.Branch_Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bills", "BillNo", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "BIllDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bills", "BillTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Customers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "SupplierId", c => c.Int());
            AddColumn("dbo.Purchases", "ReceiptNo", c => c.String());
            AddColumn("dbo.Purchases", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchases", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Purchases", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "PurchaseId", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "SupplierId", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "LotNo", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "WarehouseId", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseOrders", "RequestedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseOrders", "PromisedDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "ReceivedDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "ClosedOn", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.PurchaseOrders", "RequestedById", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "ApprovedById", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "Note", c => c.String());
            AddColumn("dbo.Sales", "CustomerId", c => c.Int());
            AddColumn("dbo.Sales", "InvoiceNo", c => c.String());
            AddColumn("dbo.Sales", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sales", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "DOB", c => c.DateTime());
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.String());
            AddColumn("dbo.Users", "IsMarried", c => c.Boolean());
            AddColumn("dbo.Users", "UserType", c => c.String());
            AddColumn("dbo.Users", "CanLogin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "DeletedAt", c => c.DateTime());
            CreateIndex("dbo.Customers", "UserId");
            CreateIndex("dbo.Users", "RoleId");
            CreateIndex("dbo.Purchases", "SupplierId");
            CreateIndex("dbo.PurchaseOrders", "PurchaseId");
            CreateIndex("dbo.PurchaseOrders", "SupplierId");
            CreateIndex("dbo.PurchaseOrders", "WarehouseId");
            CreateIndex("dbo.PurchaseOrders", "CreatedById");
            CreateIndex("dbo.PurchaseOrders", "RequestedById");
            CreateIndex("dbo.PurchaseOrders", "ApprovedById");
            CreateIndex("dbo.Sales", "CustomerId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            AddForeignKey("dbo.Customers", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.PurchaseOrders", "ApprovedById", "dbo.Users", "Id");
            AddForeignKey("dbo.PurchaseOrders", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.PurchaseOrders", "PurchaseId", "dbo.Purchases", "Id");
            AddForeignKey("dbo.PurchaseOrders", "RequestedById", "dbo.Users", "Id");
            AddForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.PurchaseOrders", "WarehouseId", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.Sales", "CustomerId", "dbo.Customers", "Id");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientReports");
            DropTable("dbo.CustomerReports");
            DropTable("dbo.Leads");
            DropTable("dbo.SaleOders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SaleOders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PurchaseOrders", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Warehouses", "Branch_Id", "dbo.Branches");
            DropForeignKey("dbo.PurchaseOrders", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrders", "RequestedById", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseOrders", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "ApprovedById", "dbo.Users");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Suppliers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.Warehouses", new[] { "Branch_Id" });
            DropIndex("dbo.PurchaseOrders", new[] { "ApprovedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "RequestedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "WarehouseId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "PurchaseId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Suppliers", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            DropColumn("dbo.Users", "DeletedAt");
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Users", "CreatedAt");
            DropColumn("dbo.Users", "RoleId");
            DropColumn("dbo.Users", "CanLogin");
            DropColumn("dbo.Users", "UserType");
            DropColumn("dbo.Users", "IsMarried");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "DOB");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.Sales", "DeletedAt");
            DropColumn("dbo.Sales", "CreatedAt");
            DropColumn("dbo.Sales", "TotalAmount");
            DropColumn("dbo.Sales", "InvoiceNo");
            DropColumn("dbo.Sales", "CustomerId");
            DropColumn("dbo.PurchaseOrders", "Note");
            DropColumn("dbo.PurchaseOrders", "ApprovedById");
            DropColumn("dbo.PurchaseOrders", "RequestedById");
            DropColumn("dbo.PurchaseOrders", "CreatedById");
            DropColumn("dbo.PurchaseOrders", "ClosedOn");
            DropColumn("dbo.PurchaseOrders", "ReceivedDate");
            DropColumn("dbo.PurchaseOrders", "PromisedDate");
            DropColumn("dbo.PurchaseOrders", "RequestedDate");
            DropColumn("dbo.PurchaseOrders", "OrderDate");
            DropColumn("dbo.PurchaseOrders", "WarehouseId");
            DropColumn("dbo.PurchaseOrders", "LotNo");
            DropColumn("dbo.PurchaseOrders", "SupplierId");
            DropColumn("dbo.PurchaseOrders", "PurchaseId");
            DropColumn("dbo.Purchases", "DeletedAt");
            DropColumn("dbo.Purchases", "CreatedAt");
            DropColumn("dbo.Purchases", "TotalAmount");
            DropColumn("dbo.Purchases", "ReceiptNo");
            DropColumn("dbo.Purchases", "SupplierId");
            DropColumn("dbo.Customers", "UserId");
            DropColumn("dbo.Bills", "BillTotal");
            DropColumn("dbo.Bills", "BIllDate");
            DropColumn("dbo.Bills", "BillNo");
            DropTable("dbo.SaleOrders");
            DropTable("dbo.Branches");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Products");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Roles");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
        }
    }
}
