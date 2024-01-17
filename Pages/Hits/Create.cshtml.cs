using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesUI.Data;
using RazorPagesUI.Model;

namespace RazorPagesUI.Pages.Hits
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public CreateModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ArtistId"] = new SelectList(_context.ArtistiColectie, "ArtistId", "ArtistName");
            return Page();
        }

        [BindProperty]
        public Hituri Hituri { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Hituri.Artist");
            if (!ModelState.IsValid)
            {
                ViewData["ArtistId"] = new SelectList(_context.ArtistiColectie, "ArtistId", "ArtistName", Hituri.ArtistId);
                return Page();
            }

            _context.Hituri.Add(Hituri);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
