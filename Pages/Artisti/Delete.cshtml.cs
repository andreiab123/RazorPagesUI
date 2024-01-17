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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public DeleteModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ArtistiColectie ArtistiColectie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ArtistiColectie == null)
            {
                return NotFound();
            }

            var artisticolectie = await _context.ArtistiColectie.FirstOrDefaultAsync(m => m.ArtistId == id);

            if (artisticolectie == null)
            {
                return NotFound();
            }
            else 
            {
                ArtistiColectie = artisticolectie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ArtistiColectie == null)
            {
                return NotFound();
            }
            var artisticolectie = await _context.ArtistiColectie.FindAsync(id);

            if (artisticolectie != null)
            {
                ArtistiColectie = artisticolectie;
                _context.ArtistiColectie.Remove(ArtistiColectie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
