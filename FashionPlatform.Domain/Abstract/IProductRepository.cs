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
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
