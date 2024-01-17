using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesUI.Data;
using RazorPagesUI.Model;

namespace RazorPagesUI.Pages.Chitare
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public DeleteModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ChitareColectie ChitareColectie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ChitareColectie == null)
            {
                return NotFound();
            }

            var chitarecolectie = await _context.ChitareColectie.FirstOrDefaultAsync(m => m.Id == id);

            if (chitarecolectie == null)
            {
                return NotFound();
            }
            else 
            {
                ChitareColectie = chitarecolectie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ChitareColectie == null)
            {
                return NotFound();
            }
            var chitarecolectie = await _context.ChitareColectie.FindAsync(id);

            if (chitarecolectie != null)
            {
                ChitareColectie = chitarecolectie;
                _context.ChitareColectie.Remove(ChitareColectie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
