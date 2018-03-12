using System.Data.Entity;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.Domain.Concrete
{
    class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        //public DbSet<Shoe> Shoes { get; set; }
        //public DbSet<Up> UpWears { get; set; }
        //public DbSet<Down> DownWears { get; set; }
        //public DbSet<Accessory> Accessories { get; set; }
        //public DbSet<ProductDestinasion> ProductDestinasions { get; set; }
        //public DbSet<TypeOfFiber> TypeOfFibers { get; set; }
        //public DbSet<Synthetic> Synthetics { get; set; }
        //public DbSet<Natural> Naturals { get; set; }
        //public DbSet<Style> Styles { get; set; }
        //public DbSet<DressCode> DressCodes { get; set; }
        //public DbSet<Cloth> Cloths { get; set; }
        //public DbSet<Thin> Thins { get; set; }
        //public DbSet<MediumThickness> MediumThicknesses { get; set; }
        //public DbSet<Cloak> Cloaks { get; set; }
        //public DbSet<Thick> Thicks { get; set; }
    }
}
