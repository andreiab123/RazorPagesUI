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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public DetailsModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        public ArtistiColectie ArtistiColectie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ArtistiColectie == null)
            {
                return NotFound();
            }

            ArtistiColectie = await _context.ArtistiColectie
                .Include(a => a.Hits)
                .Include(a => a.Guitars)
                .Include(a => a.Concerts)
                .FirstOrDefaultAsync(m => m.ArtistId == id);

            if (ArtistiColectie == null)
            {
                return NotFound();
            }

            return Page();
        }
    }

}
