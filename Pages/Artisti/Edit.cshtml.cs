using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesUI.Data;
using RazorPagesUI.Model;

namespace RazorPagesUI.Pages.Artisti
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public EditModel(RazorPagesUI.Data.RazorPagesUIContext context)
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

            var artisticolectie =  await _context.ArtistiColectie.FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artisticolectie == null)
            {
                return NotFound();
            }
            ArtistiColectie = artisticolectie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ArtistiColectie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistiColectieExists(ArtistiColectie.ArtistId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArtistiColectieExists(int id)
        {
          return (_context.ArtistiColectie?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}
