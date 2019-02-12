namespace Infrastructure.Context
{
    using Infrastructure.Entities.Bills;
    using Infrastructure.Entities.Suppliers;
    using Infrastructure.Entities.Common;
    using Infrastructure.Entities.Customers;
    using Infrastructure.Entities.Purchases;
    using Infrastructure.Entities.Sales;
    using Infrastructure.Entities.Users;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Infrastructure.Entities.Inventory;
    using System.Data.Entity.ModelConfiguration.Conventions;

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

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

       
        public virtual DbSet<Bill> Bill { get; set; }


        public virtual DbSet<Customer> Customer { get; set; }
       // public virtual DbSet<CustomerReport> CustomerReport { get; set; }

      //  public virtual DbSet<Lead> Lead { get; set; }

        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleOrder> SaleOrder { get; set; }

        public virtual DbSet<Supplier> Supplier { get; set; }
        // public virtual DbSet<SupplierReport> ClientReport { get; set; }

        public virtual DbSet<User> User { get; set; }

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

       

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}