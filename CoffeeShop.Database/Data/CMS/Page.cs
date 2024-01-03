using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Database.Data.CMS
{
    public class Page
    {
        [Key]
        public int IdPage { get; set; }
        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")] 
        [MaxLength(20, ErrorMessage = "Tytuł odnośnika nie może być dłuższy niż 20 znaków")]
        [Display(Name = "Tytuł odnośnika strony")] 
        public string LinkTitle { get; set; }

        [Required(ErrorMessage = "Tytuł strony jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytuł strony nie może być dłuższy niż 30 znaków")]
        [Display(Name = "Tytuł strony")]
        public string PageTitle { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")] 
        public string Content { get; set; }
        [Display(Name = "Pozycja wyświetlania")]
        [Required(ErrorMessage = "Pozycja wyświetlania jest wymagana")]
        public int Position { get; set; }
    }
}
