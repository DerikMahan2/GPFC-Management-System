using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GPFCManagementSystem.Models;

namespace GPFC_Management_System.Pages_Players
{
    public class IndexModel : PageModel
    {
        private readonly GPFCManagementSystem.Models.GPFCContext _context;

        public IndexModel(GPFCManagementSystem.Models.GPFCContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await _context.Players
                .Include(p => p.Team).ToListAsync();
        }
    }
}
