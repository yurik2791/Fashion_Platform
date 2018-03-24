using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.Domain.Abstract
{
    public interface IProductRepository  // Интерфейс для работы с хранилищем пользователей
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Cloth> Clothes { get; }
        IEnumerable<Shoe> Shoes { get; }
        IEnumerable<Accessory> Accessories { get; }
        IEnumerable<Country> Countries { get; }
        IEnumerable<DownWear> DownWears { get; }
        IEnumerable<UpWear> UpWears { get; }
        IEnumerable<DressCode> DressCodes { get; }
        IEnumerable<Fiber> Fibers { get; }
        IEnumerable<ProductDestination> ProductDestinasions { get; }
        IEnumerable<Style> Styles { get; }
        IEnumerable<TypeCloth> TypesCloths { get; }
        IEnumerable<TypeFiber> TypesFibers { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
