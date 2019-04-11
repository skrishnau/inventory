namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseOrderUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseItems", "VariantId", "dbo.Variants");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseOrders", "ApprovedById", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.PurchaseOrders", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseOrders", "RequestedById", "dbo.Users");
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseItems", new[] { "PurchaseId" });
            DropIndex("dbo.PurchaseItems", new[] { "VariantId" });
            DropIndex("dbo.PurchaseOrders", new[] { "PurchaseId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "WarehouseId" });
            DropIndex("dbo.PurchaseOrders", new[] { "CreatedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "RequestedById" });
            DropIndex("dbo.PurchaseOrders", new[] { "ApprovedById" });
            CreateTable(
                "dbo.PurchaseOrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrderId)
                .Index(t => t.PurchaseOrderId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "IsDiscontinued", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseOrders", "Name", c => c.String());
            AddColumn("dbo.PurchaseOrders", "OrderNumber", c => c.String());
            AddColumn("dbo.PurchaseOrders", "ParentPurchaseOrderId", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PurchaseOrders", "SupplierInvoice", c => c.String());
            AddColumn("dbo.PurchaseOrders", "ExpectedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseOrders", "IsCancelled", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseOrders", "CancelledDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "IsReceived", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseOrders", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseOrders", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseOrders", "SupplierId", c => c.Int());
            AlterColumn("dbo.PurchaseOrders", "WarehouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseOrders", "ParentPurchaseOrderId");
            CreateIndex("dbo.PurchaseOrders", "WarehouseId");
            CreateIndex("dbo.PurchaseOrders", "SupplierId");
            AddForeignKey("dbo.PurchaseOrders", "ParentPurchaseOrderId", "dbo.PurchaseOrders", "Id");
            DropColumn("dbo.PurchaseOrders", "PurchaseId");
            DropColumn("dbo.PurchaseOrders", "RequestedDate");
            DropColumn("dbo.PurchaseOrders", "PromisedDate");
            DropColumn("dbo.PurchaseOrders", "ClosedOn");
            DropColumn("dbo.PurchaseOrders", "CreatedById");
            DropColumn("dbo.PurchaseOrders", "RequestedById");
            DropColumn("dbo.PurchaseOrders", "ApprovedById");
            DropTable("dbo.Purchases");
            DropTable("dbo.PurchaseItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PurchaseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseId = c.Int(nullable: false),
                        VariantId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(),
                        ReceiptNo = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PurchaseOrders", "ApprovedById", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "RequestedById", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "CreatedById", c => c.Int());
            AddColumn("dbo.PurchaseOrders", "ClosedOn", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "PromisedDate", c => c.DateTime());
            AddColumn("dbo.PurchaseOrders", "RequestedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseOrders", "PurchaseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PurchaseOrderItems", "PurchaseOrderId", "dbo.PurchaseOrders");
            DropForeignKey("dbo.PurchaseOrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseOrders", "ParentPurchaseOrderId", "dbo.PurchaseOrders");
            DropIndex("dbo.PurchaseOrderItems", new[] { "ProductId" });
            DropIndex("dbo.PurchaseOrderItems", new[] { "PurchaseOrderId" });
            DropIndex("dbo.PurchaseOrders", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseOrders", new[] { "WarehouseId" });
            DropIndex("dbo.PurchaseOrders", new[] { "ParentPurchaseOrderId" });
            AlterColumn("dbo.PurchaseOrders", "WarehouseId", c => c.Int());
            AlterColumn("dbo.PurchaseOrders", "SupplierId", c => c.Int(nullable: false));
            DropColumn("dbo.PurchaseOrders", "UpdatedAt");
            DropColumn("dbo.PurchaseOrders", "CreatedAt");
            DropColumn("dbo.PurchaseOrders", "IsReceived");
            DropColumn("dbo.PurchaseOrders", "CancelledDate");
            DropColumn("dbo.PurchaseOrders", "IsCancelled");
            DropColumn("dbo.PurchaseOrders", "ExpectedDate");
            DropColumn("dbo.PurchaseOrders", "SupplierInvoice");
            DropColumn("dbo.PurchaseOrders", "TotalAmount");
            DropColumn("dbo.PurchaseOrders", "ParentPurchaseOrderId");
            DropColumn("dbo.PurchaseOrders", "OrderNumber");
            DropColumn("dbo.PurchaseOrders", "Name");
            DropColumn("dbo.Products", "IsDiscontinued");
            DropTable("dbo.PurchaseOrderItems");
            CreateIndex("dbo.PurchaseOrders", "ApprovedById");
            CreateIndex("dbo.PurchaseOrders", "RequestedById");
            CreateIndex("dbo.PurchaseOrders", "CreatedById");
            CreateIndex("dbo.PurchaseOrders", "WarehouseId");
            CreateIndex("dbo.PurchaseOrders", "SupplierId");
            CreateIndex("dbo.PurchaseOrders", "PurchaseId");
            CreateIndex("dbo.PurchaseItems", "VariantId");
            CreateIndex("dbo.PurchaseItems", "PurchaseId");
            CreateIndex("dbo.Purchases", "SupplierId");
            AddForeignKey("dbo.PurchaseOrders", "RequestedById", "dbo.Users", "Id");
            AddForeignKey("dbo.PurchaseOrders", "PurchaseId", "dbo.Purchases", "Id");
            AddForeignKey("dbo.PurchaseOrders", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.PurchaseOrders", "ApprovedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers", "Id");
            AddForeignKey("dbo.PurchaseItems", "VariantId", "dbo.Variants", "Id");
            AddForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases", "Id");
        }
    }
}
