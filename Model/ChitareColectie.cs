using System;
using System.ComponentModel.DataAnnotations;
namespace RazorPagesUI.Model
{
    public class ChitareColectie
    {
        public ChitareColectie()
        {
            Artist = new ArtistiColectie();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Te rog introdu titlul chitarii")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Te rog introdu modelul chitarii")]
        public string Model { get; set; }


        [Display(Name = "Data Fabricarii")]
        [DataType(DataType.Date)]
        public DateTime DataFabricarii { get; set; }

        [RegularExpression(@"[1-5]+$",ErrorMessage = "Ratingul trebuie sa fie intre 1 si 5")]
        [Required(ErrorMessage = "Te rog introdu Rating")]
        public string Rating { get; set; }

        public int ArtistId { get; set; }

        
        public virtual ArtistiColectie Artist { get; set; }
    }
}
