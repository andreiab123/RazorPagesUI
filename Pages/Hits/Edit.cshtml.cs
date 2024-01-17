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

namespace RazorPagesUI.Pages.Hits
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public EditModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hituri Hituri { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hituri == null)
            {
                return NotFound();
            }

            Hituri = await _context.Hituri
                .Include(h => h.Artist) // Include the Artist
                .FirstOrDefaultAsync(m => m.HitId == id);
            if (Hituri == null)
            {
                return NotFound();
            }

            ViewData["ArtistId"] = new SelectList(_context.ArtistiColectie, "ArtistId", "ArtistName", Hituri.ArtistId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Hituri.Artist");
            if (!ModelState.IsValid)
            {
                ViewData["ArtistId"] = new SelectList(_context.ArtistiColectie, "ArtistId", "ArtistName", Hituri.ArtistId);
                return Page();
            }

            var hituriToUpdate = await _context.Hituri.FirstOrDefaultAsync(h => h.HitId == Hituri.HitId);

            if (hituriToUpdate == null)
            {
                return NotFound();
            }

            hituriToUpdate.NumeHit = Hituri.NumeHit;
            hituriToUpdate.DataDeLansare = Hituri.DataDeLansare;
            hituriToUpdate.Album = Hituri.Album;
            hituriToUpdate.ArtistId = Hituri.ArtistId;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HituriExists(Hituri.HitId))
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

        private bool HituriExists(int id)
        {
            return _context.Hituri.Any(e => e.HitId == id);
        }

    }
}