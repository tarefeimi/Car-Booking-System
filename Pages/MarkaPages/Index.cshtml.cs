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
    public class IndexModel : PageModel
    {

        private readonly IMarkaServices _services;
        public IndexModel(IMarkaServices services)
        {
            _services = services;
        }

        public IList<Marka> Marka { get;set; }

        public void OnGet()
        {
            Marka = _services.GetMarkat().ToList();
        }
    }
}
