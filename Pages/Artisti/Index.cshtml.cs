using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUI.Data;
using RazorPagesUI.Model;

namespace RazorPagesUI.Pages.Artisti
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public IndexModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        public IList<ArtistiColectie> ArtistiColectie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ArtistiColectie != null)
            {
                // Include the Hits collection with each artist
                ArtistiColectie = await _context.ArtistiColectie
                                                .Include(a => a.Hits)
                                                .ToListAsync();
            }
        }
    }
}
