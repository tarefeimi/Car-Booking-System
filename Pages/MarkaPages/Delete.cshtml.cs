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
using RentalRazorPages.Repositories;

namespace RentalRazorPages.Pages.MarkaPages
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
        {
            private readonly IMarkaServices _services;
            public DeleteModel(IMarkaServices services)
            {
                _services = services;
            }
        public IList<Marka> Markat { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(string id)
        {
            _services.DeleteMarkat(id);
            return RedirectToPage("Index");
        }
    }  
}
