using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;

namespace RentalRazorPages.Pages.MarkaPages
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly RentalRazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(RentalRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Marka Marka { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Marka = await _context.Markat.FirstOrDefaultAsync(m => m.MarkaId == id);

            if (Marka == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
