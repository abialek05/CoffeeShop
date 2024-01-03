using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Database.Data.CMS
{
    public class CartItem
    {
        [Key]
        public int IdCartItem { get; set; }
        public string IdCartSession { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
