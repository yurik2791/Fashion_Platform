using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.WebUI.Models
{
    public class ProductViewModel
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Категория")]
        public string Category { get; set; }

        [DisplayName("Цена")]
        [Required]
        [Range(0.01, Double.MaxValue, ErrorMessage = "Please enter positive value")]
        public decimal Price { get; set; }

        [DisplayName("Страна")]
        public string CountryName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? CountryId { get; set; }

        [DisplayName("Обувь")]
        public string ShoeName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? ShoeId { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [DisplayName("Верхная одежда")]
        public string UpWearName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? UpWearId { get; set; }

        [DisplayName("Нижняя одежда")]
        public string DownWearName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? DownWearId { get; set; }

        [DisplayName("Дресс код")]
        public string DressCodeName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? DressCodeId { get; set; }

        [DisplayName("Тип волокна")]
        public string FiberName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? FiberId { get; set; }

        [DisplayName("Предназначения")]
        public string ProductDestinationName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? ProductDestinationId { get; set; }

        [DisplayName("Стиль")]
        public string StyleName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? StyleId { get; set; }

        [DisplayName("Акссесуары")]
        public string AccessoryName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? AccessoryId { get; set; }

        [DisplayName("Ткань")]
        public string ClothName { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int? ClothId { get; set; }


        //public TypeCloth TypeCloth { get; set; }
        //public string TypeFiber { get; set; }
    }
}