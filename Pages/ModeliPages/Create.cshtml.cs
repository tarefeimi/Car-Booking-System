using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;

namespace RentalRazorPages.Pages.ModeliPages
{
    public class CreateModel : PageModel
    {
        private readonly IModeletServices _services;
        private readonly IMarkaServices _markatServices;
        
        public CreateModel(IModeletServices services , IMarkaServices markaServices)
        {
            _services = services;
            _markatServices = markaServices;
        }
        [BindProperty]
        public Modeli Modeli { get; set; }

        public  IActionResult OnGet()
        {
            ViewData["MarkaId"] = new SelectList(_markatServices.GetMarkat(), "MarkaId", "MarkaEmer");
            ViewData["ModeliId"] = new SelectList(_services.GetModelet(), "ModeliId", "ModeliEmer");

            return Page();
        }
        public async Task <IActionResult> OnPostAsync(Modeli modeli)
        {
            if (modeli != null)
            {
                await _services.AddModele(modeli);
            }
            return RedirectToPage("Index");
        }
    }
}
