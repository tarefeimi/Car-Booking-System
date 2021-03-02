using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;

namespace RentalRazorPages.Pages.ModeliPages
{
    public class DetailsModel : PageModel
    {
        private readonly RentalRazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(RentalRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Modeli Modeli { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Modeli = await _context.Modelet
                .Include(m => m.Marka).FirstOrDefaultAsync(m => m.ModeliId == id);

            if (Modeli == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
