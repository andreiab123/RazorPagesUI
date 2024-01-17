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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesUI.Data.RazorPagesUIContext _context;

        public IndexModel(RazorPagesUI.Data.RazorPagesUIContext context)
        {
            _context = context;
        }

        public IList<Concert> Concert { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Concerte != null)
            {
                Concert = await _context.Concerte
                .Include(c => c.Artist).ToListAsync();
            }
        }
    }
}
