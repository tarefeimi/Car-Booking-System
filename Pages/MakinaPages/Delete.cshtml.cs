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

namespace RentalRazorPages.Pages.MakinaPages
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
    
        private readonly IMakinaServices _services;
        public DeleteModel(IMakinaServices services)
        {
                _services = services;
        }
        public Makina Makina { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
       public  IActionResult OnPost(Guid id )
       {
            _services.DeleteMakinat(id);
            return RedirectToPage("Index");          
       }

    }
}
