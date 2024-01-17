using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUI.Data;
using RazorPagesUI.Model;

namespace RazorPagesUI.Pages.Concerts
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public DeleteModel(RazorPagesUI.Data.RazorPagesUIContext context)
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

            var concert = await _context.Concerte.FirstOrDefaultAsync(m => m.ConcertId == id);

            if (concert == null)
            {
                return NotFound();
            }
            else 
            {
                Concert = concert;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Concerte == null)
            {
                return NotFound();
            }
            var concert = await _context.Concerte.FindAsync(id);

            if (concert != null)
            {
                Concert = concert;
                _context.Concerte.Remove(Concert);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
