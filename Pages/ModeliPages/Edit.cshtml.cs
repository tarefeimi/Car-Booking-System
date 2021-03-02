using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;

namespace RentalRazorPages.Pages.ModeliPages
{
        [BindProperties(SupportsGet = true)]
    public class EditModel : PageModel
    {
        private readonly IModeletServices _services;
       private readonly IMarkaServices _markatServices;
        public EditModel(IModeletServices services, IMarkaServices markaServices)
        {
            _services = services;
           _markatServices = markaServices;
        }

        public Modeli Modeli { get; set; }

        public List<SelectListItem> Markat { get; set; }

        public IActionResult OnGet(string Id)
        {

            Markat = _markatServices.GetMarkat().Select(x => new SelectListItem
            {
                Text = x.MarkaId,
                Value = x.MarkaId
            }).ToList();

            Modeli = _services.GetModeli(Id);
            //ViewData["MarkaId"] = new SelectList(_markatServices.GetMarkat(), "MarkaId", "MarkaEmer");

            //   Marka = _markatServices.GetMarka(MId);
            //  ViewData["ModeliId"] = new SelectList(_services.GetModelet(), "ModeliId", "ModeliEmer");

            //if (Modeli != null)
            //{
            //    return RedirectToPage("/Index");
            //}
            return Page();
        }
        public IActionResult OnPost(Modeli modeli)
        {
            _services.UpdateModelet(modeli);
            return RedirectToPage("Index");
        }
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
        //   ViewData["MarkaId"] = new SelectList(_context.Markat, "MarkaId", "MarkaId");
        //    return Page();
        //}

        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(Modeli).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ModeliExists(Modeli.ModeliId))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        //private bool ModeliExists(string id)
        //{
        //    return _context.Modelet.Any(e => e.ModeliId == id);
        //}
    }
}
