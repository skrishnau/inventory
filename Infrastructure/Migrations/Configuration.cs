namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.Context.DatabaseContext>
    {
        public Configuration()
        {
#if DEBUG
            AutomaticMigrationsEnabled = false;
#else
            AutomaticMigrationsEnabled = true;
#endif
        }

        protected override void Seed(Infrastructure.Context.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
