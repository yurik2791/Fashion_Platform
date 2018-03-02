using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionPlatform.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your first adress")]
        [Display(Name = "First Adress")]
        public string Line1 { get; set; }
        [Display(Name = "Second Adress")]
        public string Line2 { get; set; }
        [Display(Name = "Third Adress")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter your country")]
        public string Country { get; set; }


        public bool GiftWrap { get; set; }
    }
}
