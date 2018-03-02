using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FashionPlatform.Domain.Entities;

namespace FashionPlatform.WebUI.Models
{
    public class CartIndexViewModels
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}