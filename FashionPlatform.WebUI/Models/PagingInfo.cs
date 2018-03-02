using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionPlatform.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalPage
        {
            get { return (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage); }
        } // Обшее количество страниц

        public int CurrentPage { get; set; } // Тякушая страница
        public int ItemsPerPage { get; set; } // Количество продуктов на стринице
        public int TotalItems { get; set; } //Обшее количество продуктов
    }
}