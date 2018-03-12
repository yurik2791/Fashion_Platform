using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionPlatform.Domain.Entities
{
    public class Person // Пользователь
    {
        [Key]
        public int ProductID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Adress Adress { get; set; }
        public string PhoneNumber { get; set; }
        [Range(16,100,ErrorMessage = "Введите правильное занчение для возраста")]
        public int Age { get; set; } // Возраст

        [Range(25, 200, ErrorMessage = "Введите правильное занчение для веса")]
        public int Weight { get; set; } //Вес

        [Range(50, 250, ErrorMessage = "Введите правильное занчение для роста")]
        public int Height { get; set; } // Рост 

        public int Arm { get; set; }  //Длина руки

        public int Shoes { get; set; } // Размер обуви

        public int Leg { get; set; } // Внутренняя длина ноги

        public int Foot { get; set; } // Длина стопы

        public int Waist { get; set; } // Обьем талии

        public int Thigs { get; set; } // Обхват бедер

        public int Head { get; set; } // Обьем головы

        public int Neck { get; set; } // Обьем шеи

        public int Thigh { get; set; } // Обхват бедра 

        public int Shoulder { get; set; } // Ширина плеч

        public int Wrist { get; set; } // Ширина запястья

        public int Chest { get; set; } // Обхват груди

        public int UnderBreast { get; set; } // Обхват под грудью
        public Sex PersonSex { get; set; }
        public ColorType PersonColorType { get; set; }
    }

    public enum Sex // Пол
        {
            Men,
            Women
        }
        public enum ColorType // Цветотипы внешности
        {
            ColdWinter,        // Холодная зима
            ColdSummer,        // Холодное лето
            LightSummer,       // Светлое лето 
            LightSpring,       // Светлая весна
            SoftSummer,        // Мягкое лето
            SoftAutumn,        // Мягкая осень
            WarmAutumn,        // Теплая осень
            WarmSpring,        // Теплая весна
            DarkWinter,        // Темная зима
            DarkAutumn,        // Темная осень
            BrightSpring,      // Яркая весна
            BrightWinter       // Яркая зима

        }
    

    public class Adress
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string AdressLine3 { get; set; }
        public string ZipCode { get; set; }
    }
}