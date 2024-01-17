using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesUI.Data;
using RazorPagesUI.Model;

namespace RazorPagesUI.Pages.Artisti
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
        public ArtistiColectie ArtistiColectie { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ArtistiColectie == null || ArtistiColectie == null)
            {
                return Page();
            }

            _context.ArtistiColectie.Add(ArtistiColectie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
