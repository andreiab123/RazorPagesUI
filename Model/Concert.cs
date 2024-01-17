using System.ComponentModel.DataAnnotations;

namespace RazorPagesUI.Model
{
    public class Concert
    {
        [Key]
        public int ConcertId { get; set; }

        public string NumeConcert { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataConcert { get; set; }

        public string Locatie { get; set; }

        // Cheie straina pentru artist
        public int ArtistId { get; set; }

        // proprietate navigationala pentru artist
        public virtual ArtistiColectie Artist { get; set; }
    }

}
