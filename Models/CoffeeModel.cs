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
        public string CoffeeImg { get; set; }
        public string CoffeeRating { get; set; }
        public float CoffeePrice { get; set; }
        public int CoffeeMilk { get; set; }
        public int CoffeeSugar { get; set; }
        public int CoffeeSalt { get; set; }
        public int CoffeeGinger { get; set; }
        public int CoffeeSmall { get; set; }
        public int CoffeeMedium { get; set; }
        public int CoffeeLarge { get; set; }
    }
}