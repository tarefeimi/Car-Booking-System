using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;

namespace RentalRazorPages.Pages.MarkaPages
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IMarkaServices _services;
        public EditModel(IMarkaServices services)
        {
            _services = services;
        }

        [BindProperty]
        public Marka Marka { get; set; } 
        public IActionResult OnGet(string Id)
        {
             Marka= _services.GetMarka(Id);
            if (Marka==null)
            {
               return RedirectToPage("/Index");
            }
            return Page();
        }  
        public IActionResult OnPost(Marka marka)
        {
            _services.UpdateMarkat(marka);
            return RedirectToPage("Index");
        }
    }
}
