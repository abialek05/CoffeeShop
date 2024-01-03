using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoffeeShop.Database.Data.CMS
{
	public class Product:TEntity
	{
        [Key]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana.")]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength(100, ErrorMessage = "Nazwa produktu nie może być dłuższa niż 100 znaków.")]
        [Display(Name = "Nazwa produktu")]
        public string ProductName { get; set; }

        [Display(Name = "Typ produktu")]
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public  ProductType ProductType { get; set; }

        [Display(Name = "Kraj pochodzenia")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string CountryOrigin { get; set; }
        [Display(Name = "Opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        [Display(Name = "Szczegółowy opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string DescriptionLong { get; set; }
        [Display(Name = "Nuty smakowe")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string FlavorNotes { get; set; }
        [Display(Name = "Waga w gramach")]
        public int Weight { get; set; }
        [Display(Name = "Cena")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Display(Name = "URL zdjęcia")]
        public string PhotoURL { get; set; }

        [Display(Name = "Poziom zmielenia")]
        [ForeignKey("GrindLevel")]       
        public int GrindLevelId { get; set; }
        public  GrindLevel GrindLevel { get; set; }
        [Display(Name = "Aktywny")]
        public bool IsActive { get; set; }
    }
}
