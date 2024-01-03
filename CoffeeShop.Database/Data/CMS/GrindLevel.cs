using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Database.Data.CMS
{
    public class GrindLevel
    {
        [Key]
        public int IdGrindLevel { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Required(ErrorMessage = "Rodzaj zmielenia jest wymagany")]
        [Display(Name = "Rodzaj zmielenia")]
        public string GrindName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Aktywny")]       
        public bool IsActive { get; set; }
    }
}
