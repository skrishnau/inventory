namespace Infrastructure.Context
{
    using Infrastructure.Entities.Bills;
    using Infrastructure.Entities.Suppliers;
    using Infrastructure.Entities.Common;
    using Infrastructure.Entities.Customers;
    using Infrastructure.Entities.Orders;
    using Infrastructure.Entities.Users;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Infrastructure.Entities.Inventory;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Infrastructure.Entities.Business;
    using Infrastructure.Entities.AppSettings;
    using System.Data.SqlClient;
    using System.Data.Entity.Core.EntityClient;

    public class DatabaseContext : DbContext
    {
        // Your context has been configured to use a 'DatabaseContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Infrastructure.Context.DatabaseContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DatabaseContext' 
        // connection string in the application configuration file.
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public DatabaseContext(string connectionString)
            :base (connectionString)
        {

        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        // ===================== BILL MODULE ================== //
        public virtual DbSet<Bill> Bill { get; set; }


        // =================== BUSINESS MODULE ===================== //
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }


        // =================== HRM MODULE ======================//
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<BasicInfo> BasicInfo { get; set; }
        //  public virtual DbSet<Lead> Lead { get; set; }


        // ================== INVENTORY MODULE ================== //
       // public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttribute { get; set; }
       // public virtual DbSet<Variant> Variant { get; set; }
        public virtual DbSet<Uom> Uom { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<AdjustmentCode> AdjustmentCode { get; set; }
        // public virtual DbSet<VariantAttribute> VariantAttribute { get; set; }
        public virtual DbSet<Transfer> Transfer { get; set; }
        public virtual DbSet<WarehouseProduct> WarehouseProduct { get; set; }
        public virtual DbSet<InventoryUnit> InventoryUnit { get; set; }


        // ===================== TRANSACTION MODULE ==================== //
        //public virtual DbSet<Sale> Sales { get; set; }
        //public virtual DbSet<SaleOrder> SaleOrder { get; set; }
        //public virtual DbSet<SaleItem> SaleItems { get; set; }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }

        public virtual DbSet<AppSetting> AppSetting { get; set; }

        public virtual DbSet<Movement> Movement { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // for now cascade delete is removed for all entities
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Add<CascadeDeleteAttributeConvention>();

            //modelBuilder.Entity<Supplier>()
            //    .HasRequired<User>(s=>s.User)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);
        }


        public static DatabaseContext ConnectToSqlServer(string host, string catalog, string user, string pass, bool winAuth)
        {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = host,
                InitialCatalog = catalog,
                PersistSecurityInfo = true,
                IntegratedSecurity = winAuth,
                MultipleActiveResultSets = true,
                UserID = user,
                Password = pass,
            };

            // assumes a connectionString name in .config of MyDbEntities
            var entityConnectionStringBuilder = new EntityConnectionStringBuilder
            {
                Provider = "System.Data.SqlClient",
                ProviderConnectionString = sqlBuilder.ConnectionString,
                Metadata = "res://*/DbModel.csdl|res://*/DbModel.ssdl|res://*/DbModel.msl",
            };

            return new DatabaseContext(entityConnectionStringBuilder.ConnectionString);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}