using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUI.Data;
using RazorPagesUI.Model;

namespace RazorPagesUI.Pages.Hits
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public DeleteModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Hituri Hituri { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hituri == null)
            {
                return NotFound();
            }

            var hituri = await _context.Hituri.FirstOrDefaultAsync(m => m.HitId == id);

            if (hituri == null)
            {
                return NotFound();
            }
            else 
            {
                Hituri = hituri;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hituri == null)
            {
                return NotFound();
            }
            var hituri = await _context.Hituri.FindAsync(id);

            if (hituri != null)
            {
                Hituri = hituri;
                _context.Hituri.Remove(Hituri);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
