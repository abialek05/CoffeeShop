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
    public class Training
    {
        [Key]
        public int IdTraining { get; set; }

        [Required(ErrorMessage = "Nazwa szkolenia jest wymagana.")]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Nazwa szkolenia")]
        public string TrainingName { get; set; }

        [Display(Name = "Data rozpoczęcia szkolenia")]
        [Required(ErrorMessage = "Data rozpoczęcia jest wymagana.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Data zakończenia jest wymagana.")]
        [Display(Name = "Data zakończenia szkolenia")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Koszt szkolenia")]
        [Required(ErrorMessage = "Cena za szkolenie jest wymagana.")]
        public decimal Price { get; set; }
        [Display(Name = "Ilość miejsc")]
        [Required(ErrorMessage = "Ilość miejsc jest wymagana.")]
        public int Spots { get; set; }

        [Display(Name = "Opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        [Display(Name = "URL zdjęcia")]
        public string PhotoURL { get; set; }

        [Display(Name = "Aktywny")]
        public bool IsActive { get; set; }

    }
}
