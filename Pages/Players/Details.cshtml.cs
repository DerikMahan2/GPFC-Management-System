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
    public class DetailsModel : PageModel
    {
        private readonly GPFCManagementSystem.Models.GPFCContext _context;

        public DetailsModel(GPFCManagementSystem.Models.GPFCContext context)
        {
            _context = context;
        }

        public Player Player { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            else
            {
                Player = player;
            }
            return Page();
        }
    }
}
