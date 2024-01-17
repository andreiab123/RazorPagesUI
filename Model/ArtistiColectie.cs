using System.ComponentModel.DataAnnotations;
namespace RazorPagesUI.Model
{
    public class ArtistiColectie
    {
        public ArtistiColectie()
        {
            Hits = new List<Hituri>();
            Guitars = new List<ChitareColectie>();
            Concerts = new List<Concert>();
        }

        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Genre { get; set; }
        public string BiggestHit { get; set; }
        public string FavoriteGuitar { get; set; }

        // Proprietati navigationale
        public virtual ICollection<Hituri> Hits { get; set; }
        public virtual ICollection<ChitareColectie> Guitars { get; set; }
        public virtual ICollection<Concert> Concerts { get; set; }
    }
}