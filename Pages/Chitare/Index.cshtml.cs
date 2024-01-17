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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public IndexModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        public IList<ChitareColectie> ChitareColectie { get;set; } = default!;

        public async Task OnGetAsync(string? SearchString)
        {
            var chitare = from b in _context.ChitareColectie
                          select b;

            if (!String.IsNullOrEmpty(SearchString))
            {
                chitare = _context.ChitareColectie.Where(s => s.Title!.Contains(SearchString));
            }

            ChitareColectie = await chitare.ToListAsync();
        }
    }
}
