using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JCoffee.Models
{
    public class CoffeeModel
    {
        public int Id { get; set; }
        public string CoffeeName { get; set; }
        public string CoffeeSub { get; set; }
        public string CoffeeDesc { get; set; }
    }
}