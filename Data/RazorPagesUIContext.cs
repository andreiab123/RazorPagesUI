using Microsoft.EntityFrameworkCore;

namespace RazorPagesUI.Data
{
    public class RazorPagesUIContext : DbContext
    {
        public RazorPagesUIContext(DbContextOptions<RazorPagesUIContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesUI.Model.ChitareColectie> ChitareColectie { get; set; } = default!;

        public DbSet<RazorPagesUI.Model.ArtistiColectie>? ArtistiColectie { get; set; }

        public DbSet<RazorPagesUI.Model.Hituri>? Hituri { get; set; }
        public DbSet<RazorPagesUI.Model.Concert>? Concerte { get; set; }

    }
}
