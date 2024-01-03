using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Database.Data.CMS
{
    public class ProductType
    {
        [Key]
        public int IdProductType { get; set; }
        [Required(ErrorMessage = "Typ produktu jest wymagany")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Typ produktu")]
        public string TypeName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Aktywny")]
        public bool IsActive { get; set; }

        public IList<Product> Product { get; } = new List<Product>();
    }
}
