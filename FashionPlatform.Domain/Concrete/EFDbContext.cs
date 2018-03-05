using System.Data.Entity;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.Domain.Concrete
{
    class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
