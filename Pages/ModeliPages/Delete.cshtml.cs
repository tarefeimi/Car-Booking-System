using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;

namespace RentalRazorPages.Pages.ModeliPages
{
    public class DeleteModel : PageModel
    {
        private readonly IModeletServices _services;
        public DeleteModel(IModeletServices services)
        {
            _services = services;
        }
        public IList<Modeli> Modeli { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(string id)
        {
            _services.DeleteModelet(id);
            return RedirectToPage("Index");
        }
    }

}
//private readonly RentalRazorPages.Data.ApplicationDbContext _context;

//public DeleteModel(RentalRazorPages.Data.ApplicationDbContext context)
//{
//    _context = context;
//}

//[BindProperty]
//public Modeli Modeli { get; set; }

//public async Task<IActionResult> OnGetAsync(string id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    Modeli = await _context.Modelet
//        .Include(m => m.Marka).FirstOrDefaultAsync(m => m.ModeliId == id);

//    if (Modeli == null)
//    {
//        return NotFound();
//    }
//    return Page();
//}

//public async Task<IActionResult> OnPostAsync(string id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    Modeli = await _context.Modelet.FindAsync(id);

//    if (Modeli != null)
//    {
//        _context.Modelet.Remove(Modeli);
//        await _context.SaveChangesAsync();
//    }

//    return RedirectToPage("./Index");
//}

