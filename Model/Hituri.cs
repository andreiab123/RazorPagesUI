using System.ComponentModel.DataAnnotations;
namespace RazorPagesUI.Model
{
    public class Hituri
    {
        [Key]
        public int HitId { get; set; }

        public string NumeHit { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataDeLansare { get; set; }

        public string Album { get; set; }

        //cheie straina pentru artist
        public int ArtistId { get; set; }

        // proprietate navigationala pentru artist
        public virtual ArtistiColectie Artist { get; set; }
    }
}