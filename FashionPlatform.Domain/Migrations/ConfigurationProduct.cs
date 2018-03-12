namespace FashionPlatform.Domain.Migrations.MigrationProduct
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationProduct : DbMigrationsConfiguration<FashionPlatform.Domain.Concrete.EFDbContext>
    {
        public ConfigurationProduct()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FashionPlatform.Domain.Concrete.EFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
