using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;

namespace RentalRazorPages.Pages.MakinaPages
{
    public class DetailsModel : PageModel
    {
        private readonly RentalRazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(RentalRazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Makina Makina { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Makina = await _context.Makinat
                .Include(m => m.Marka)
                .Include(m => m.Modeli).FirstOrDefaultAsync(m => m.MakinaId == id);

            if (Makina == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
