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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public IndexModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        public IList<Hituri> Hituri { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hituri != null)
            {
                Hituri = await _context.Hituri.ToListAsync();
            }
        }
    }
}
