using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesUI.Data;
using RazorPagesUI.Model;

namespace RazorPagesUI.Pages.Chitare
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
            return Page();
        }

        [BindProperty]
        public ChitareColectie ChitareColectie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ChitareColectie == null || ChitareColectie == null)
            {
                return Page();
            }

            _context.ChitareColectie.Add(ChitareColectie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
