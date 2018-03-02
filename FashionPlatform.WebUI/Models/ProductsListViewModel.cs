using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.WebUI.Models
{
    public class ProductsListViewModel //Класс для передачи данных о продуктах и их расположение на странице в представление
    {
        public IEnumerable<Product> Products { get; set;} // Продукты передаваемые в преставление
        public PagingInfo PagingInfo { get; set; } // Данные страницы
        public string CurrentCategory { get; set; } // Текущая категория продукта для фильтраций списка всех продуктов
    }
}