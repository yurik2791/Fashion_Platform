using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FashionPlatform.Domain.Entities
{
    public class Product
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; } // Для изменение имени свойства в форме использовать атрибут [Display(Name=".....")]

        [Required(ErrorMessage = "Please enter product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description of product")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter product category")]
        public string Category { get; set; }

        [Required]
        [Range(0.01, Double.MaxValue, ErrorMessage = "Please enter positive value")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public int? CountryId { get; set; }
        public int? ShoeId { get; set; }
        public int? UpWearId { get; set; }
        public int? DownWearId { get; set; }
        public int? AccessoryId { get; set; }
        public int? ProductDestinationId { get; set; }
        public int? FiberId { get; set; }
        public int? ClothId { get; set; }
        public int? StyleId { get; set; }
        public int? DressCodeId { get; set; }

    }

    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
    public class Shoe
    {
        public int ShoeId { get; set; }
        public string ShoeName { get; set; }
    }
    public class UpWear
    {
        public int UpWearId { get; set; }
        public string UpWearName { get; set; }
    }
    public class DownWear
    {
        public int DownWearId { get; set; }
        public string DownWearName { get; set; }
    }
    public class Accessory
    {
        public int AccessoryId { get; set; }
        public string AccessoryName { get; set; }
    }
    public class ProductDestination
    {
        public int ProductDestinationId { get; set; }
        public string ProductDestinationName { get; set; }
    }
    public class TypeFiber
    {
        public int TypeFiberId { get; set; }
        public string TypeFiberName { get; set; }
    }

    public class Fiber
    {
        public int FiberId { get; set; }
        public string FiberName { get; set; }
        public int TypeFiberId { get; set; }
    }
    public class TypeCloth
    {
        public int TypeClothId { get; set; }
        public string TypeClothName { get; set; }
    }
    public class Cloth
    {
        public int ClothId { get; set; }
        public string ClothName { get; set; }
        public int TypeClothId { get; set; }
    }

    public class Style
    {
        public int StyleId { get; set; }
        public string StyleName { get; set; }
    }
    public class DressCode
    {
        public int DressCodeId { get; set; }
        public string DressCodeName { get; set; }
    }

    //public enum Shoes
    //{
    //    Balletshoes,        //балетки
    //    HighBoots,          //сапоги
    //    HighHeelShoes,  // туфли
    //    LowBoots        //ботинки
    //}

    //public enum UpWear
    //{
    //    Shirt,      //Рубашка
    //    Undershirt, //Майка
    //    Blouze,     //блузка
    //    TShirt,     //футболка
    //    Cardigan,   //Кардиган
    //    Jacket,     //пиджак
    //    Dress,      //платье
    //    Overalls,   //комбинезон
    //    Pullover,   //свитер
    //    Bolero,     //болеро
    //}

    //public enum DownWear
    //{
    //    Overalls,   //комбинезон
    //    Dress,      //платье
    //    Pants,      //брюки
    //    Capris,     //капри
    //    Skirt,      //юбка
    //    Tights,     //колготы
    //    Soks,       //носки
    //    Stockings   //чулки
    //}

    //public enum Accesories
    //{
    //    Rings,      //кольца
    //    Eerrings,   //серьги
    //    Necklaces,  //ожерелье
    //    Braclets,   //браслет
    //    Bags,       //сумка
    //    Strap,      //ремень
    //    Shawl,      //платок
    //    Scarf,      //шарф
    //    Kerchief,   //косынка

    //}

    //public enum ProductDestinasion
    //{
    //    EveningWear,    //вечерние наряды
    //    Blouse,         //блузка
    //    Underwear,      //нижнее белье
    //    SummerWear,     //летняя одежда
    //    WinterWear,     //зимняя одежда
    //    EveryDayWear,   //повседневная одежда
    //    Accessories,    //аксессуары
    //    BusinessWear,   //деловая одежда
    //    BaseWear,       //базовая одежда
    //    SportsWear      //спортивная одежда
    //}


    //public enum TypeOfFiber //Тип волокна
    //{
    //    Natural,
    //    Synthetic,

    //}

    //public enum Natural
    //    {
    //        Cotton,     //хлопок
    //        Flax,       //лен
    //        Asbestos,   //асбест
    //        Wool,       //шерсть
    //        Silk        //шелк
    //    }

    //    public enum Synthetic
    //    {
    //        Viscose,    //вискоза
    //        Acetate,    //ацетат
    //        Polyester,  //полиэстер
    //        Acrylic,    //акрил
    //        Nylon,      //нейлон
    //        Polyurethane//полиуретан 
    //    }


    //public class Cloth      //Ткань
    //{
    //    public enum Thin        //Тонкая
    //    {
    //        Batiste,    //батист
    //        Marquisite, //маркизет
    //        Voile,      //вуаль
    //        Chiffon,    //шифон
    //        Georgette,  //жоржет
    //    }

    //    public enum MediumThickness     //Средней толщины
    //    {
    //        Cashmere,   //кашемир
    //        Knitwear,   //трикотаж
    //    }

    //    public enum Cloak   //Плащевые
    //    {
    //        Atlas,      //атлас
    //        Satin,      //Сатин
    //        Taffeta,    //тафта
    //        Brocade,    //Парча
    //        Damascus,   //дамаск
    //        Velvet,     //бархат
    //        Velveteen,  //вельвет
    //        Velours,    //велюр
    //        Bike,       //байка
    //        CrepeВeСhine,//крепдешин
    //        Organza,    //органза
    //        }

    //    public enum Thick
    //    {
    //        Gabardine,  //габардин
    //        Cloth,      //сукно
    //        DiagonalCloth,//диагональ
    //        Tweed,      //твид
    //        Jersey,     //джерси
    //        Boucle,     //букле
    //        Drapery,    //драп
    //        Ratin,      //ратин
    //        Leather,    //кожа
    //        Fur,        //мех
    //        PileCloth, //ткань с ворсом
    //    }
    //}

    //public enum Style
    //{
    //    Official,       //официальный
    //    AvantGarde,     //авангард
    //    Glamor,         //гламур
    //    Classic,        //классика
    //    Country,        //кантри
    //    Bohemia,        //богема
    //    Vintage,        //винтаж
    //    Grunge,         //гранж
    //    Casual,         //кэжуал
    //    Military,       //милитари
    //    }

    //public enum DressCode
    //{
    //    Street,         //уличный
    //    Everyday,       //повседневный
    //    DayToDayBusiness,//повседневно-деловой
    //    DayToDayElegantly,//элегантно-повседневный
    //    BusinessStyle,  //деловой стиль
    //    SpecialBusinessStyle,//деловой стиль для особых случаев


    //}
}