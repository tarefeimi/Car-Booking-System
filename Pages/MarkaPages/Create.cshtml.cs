using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;

namespace RentalRazorPages.Pages.MarkaPages
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IMarkaServices _services;
        public CreateModel( IMarkaServices services)
        {
            _services = services;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Marka Marka { get; set; }
        public async Task <IActionResult> OnPostAsync(Marka marka)
        {
            if (marka != null)
            {
                await _services.AddMarka(marka);         
            }
            return RedirectToPage("Index");
        }
    }
}
