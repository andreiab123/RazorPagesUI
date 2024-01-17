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

namespace RazorPagesUI.Pages.Chitare
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public EditModel(RazorPagesUI.Data.RazorPagesUIContext context)
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

            var chitarecolectie =  await _context.ChitareColectie.FirstOrDefaultAsync(m => m.Id == id);
            if (chitarecolectie == null)
            {
                return NotFound();
            }
            ChitareColectie = chitarecolectie;
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

            _context.Attach(ChitareColectie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChitareColectieExists(ChitareColectie.Id))
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

        private bool ChitareColectieExists(int id)
        {
          return (_context.ChitareColectie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
