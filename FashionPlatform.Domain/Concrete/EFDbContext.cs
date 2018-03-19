using System.Data.Entity;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.Domain.Concrete
{
    class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<UpWear> UpWears { get; set; }
        public DbSet<DownWear> DownWears { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<ProductDestinasion> ProductDestinasions { get; set; }
        public DbSet<TypeFiber> TypesFibers { get; set; }
        public DbSet<Fiber> Fibers { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<DressCode> DressCodes { get; set; }
        public DbSet<Cloth> Cloths { get; set; }
        public DbSet<TypeCloth> TypesCloths { get; set; }
    }
}
