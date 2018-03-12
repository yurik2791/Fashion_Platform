namespace FashionPlatform.Domain.Migrations.MigrationUsers
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationUsers : DbMigrationsConfiguration<FashionPlatform.Domain.UserAndRole.Infrastructure.AppIdentityDbContext>
    {
        public ConfigurationUsers()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FashionPlatform.Domain.UserAndRole.Infrastructure.AppIdentityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
