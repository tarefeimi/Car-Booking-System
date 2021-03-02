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

namespace RentalRazorPages.Pages.ModeliPages
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IModeletServices _services;
        private readonly IMarkaServices _markatServices;
        public IndexModel(IModeletServices services , IMarkaServices markatServices)
        {
            _services = services;
            _markatServices = markatServices;        
        }

        public IList<Modeli> Modeli { get;set; }
        public IList<Marka> Marka { get; set; }

        public  void OnGet()
        {
            Modeli =_services.GetModelet().ToList();
            Marka = _markatServices.GetMarkat().ToList();
        }
    }
}
