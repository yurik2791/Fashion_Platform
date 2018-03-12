using System;
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
        public string Country { get; set; }
        public string Shoe { get; set; }
        public string UpWear { get; set; }
        public string DownWear { get; set; }
        public string Accessory { get; set; }
        public string ProductDestinasion { get; set; }
        public string Fiber { get; set; }
        public string Cloth { get; set; }
        public string Style { get; set; }
        public string DressCode { get; set; }

    }

    public enum Shoes
    {
        Balletshoes,        //балетки
        HighBoots,          //сапоги
        HighHeelShoes,  // туфли
        LowBoots        //ботинки
    }

    public enum Up
    {
        Shirt,      //Рубашка
        Undershirt, //Майка
        Blouze,     //блузка
        TShirt,     //футболка
        Cardigan,   //Кардиган
        Jacket,     //пиджак
        Dress,      //платье
        Overalls,   //комбинезон
        Pullover,   //свитер
        Bolero,     //болеро
    }

    public enum Down
    {
        Overalls,   //комбинезон
        Dress,      //платье
        Pants,      //брюки
        Capris,     //капри
        Skirt,      //юбка
        Tights,     //колготы
        Soks,       //носки
        Stockings   //чулки
    }

    public enum Accesories
    {
        Rings,      //кольца
        Eerrings,   //серьги
        Necklaces,  //ожерелье
        Braclets,   //браслет
        Bags,       //сумка
        Strap,      //ремень
        Shawl,      //платок
        Scarf,      //шарф
        Kerchief,   //косынка

    }

    public enum ProductDestinasion
    {
        EveningWear,    //вечерние наряды
        Blouse,         //блузка
        Underwear,      //нижнее белье
        SummerWear,     //летняя одежда
        WinterWear,     //зимняя одежда
        EveryDayWear,   //повседневная одежда
        Accessories,    //аксессуары
        BusinessWear,   //деловая одежда
        BaseWear,       //базовая одежда
        SportsWear      //спортивная одежда
    }


    public class TypeOfFiber        //Тип волокна
    {
        public enum Natural
        {
            Cotton,     //хлопок
            Flax,       //лен
            Asbestos,   //асбест
            Wool,       //шерсть
            Silk        //шелк
        }

        public enum Synthetic
        {
            Viscose,    //вискоза
            Acetate,    //ацетат
            Polyester,  //полиэстер
            Acrylic,    //акрил
            Nylon,      //нейлон
            Polyurethane//полиуретан 
        }

    }

    public class Cloth      //Ткань
    {
        public enum Thin        //Тонкая
        {
            Batiste,    //батист
            Marquisite, //маркизет
            Voile,      //вуаль
            Chiffon,    //шифон
            Georgette,  //жоржет
        }

        public enum MediumThickness     //Средней толщины
        {
            Cashmere,   //кашемир
            Knitwear,   //трикотаж
        }

        public enum Cloak   //Плащевые
        {
            Atlas,      //атлас
            Satin,      //Сатин
            Taffeta,    //тафта
            Brocade,    //Парча
            Damascus,   //дамаск
            Velvet,     //бархат
            Velveteen,  //вельвет
            Velours,    //велюр
            Bike,       //байка
            CrepeВeСhine,//крепдешин
            Organza,    //органза
            }

        public enum Thick
        {
            Gabardine,  //габардин
            Cloth,      //сукно
            DiagonalCloth,//диагональ
            Tweed,      //твид
            Jersey,     //джерси
            Boucle,     //букле
            Drapery,    //драп
            Ratin,      //ратин
            Leather,    //кожа
            Fur,        //мех
            PileCloth, //ткань с ворсом
        }
    }

    public enum Style
    {
        Official,       //официальный
        AvantGarde,     //авангард
        Glamor,         //гламур
        Classic,        //классика
        Country,        //кантри
        Bohemia,        //богема
        Vintage,        //винтаж
        Grunge,         //гранж
        Casual,         //кэжуал
        Military,       //милитари
        }

    public enum DressCode
    {
        Street,         //уличный
        Everyday,       //повседневный
        DayToDayBusiness,//повседневно-деловой
        DayToDayElegantly,//элегантно-повседневный
        BusinessStyle,  //деловой стиль
        SpecialBusinessStyle,//деловой стиль для особых случаев


    }

}
