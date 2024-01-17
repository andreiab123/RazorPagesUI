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

namespace RazorPagesUI.Pages.Concerts
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public EditModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Concert Concert { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Concerte == null)
            {
                return NotFound();
            }

            var concert =  await _context.Concerte.FirstOrDefaultAsync(m => m.ConcertId == id);
            if (concert == null)
            {
                return NotFound();
            }
            Concert = concert;
           ViewData["ArtistId"] = new SelectList(_context.ArtistiColectie, "ArtistId", "ArtistId");
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

            _context.Attach(Concert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcertExists(Concert.ConcertId))
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

        private bool ConcertExists(int id)
        {
          return (_context.Concerte?.Any(e => e.ConcertId == id)).GetValueOrDefault();
        }
    }
}
