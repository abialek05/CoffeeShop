using CoffeeShop.Database.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Portal.Models.Shop
{
    public class CartData
    {
		public List<CartItem> CartItems { get; set; }
        public decimal Total { get; set; }
    }
}
