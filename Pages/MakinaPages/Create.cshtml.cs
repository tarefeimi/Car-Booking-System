using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace RentalRazorPages.Pages.MakinaPages
{
    [Authorize(Roles = "Admin")]
    [BindProperties(SupportsGet = true)]

    public class CreateModel : PageModel
    {
        private readonly IMakinaServices _services;
        private readonly IModeletServices _modeletServices;
        private readonly IMarkaServices _markatServices;
        private readonly IWebHostEnvironment ihostingEnvironment;
        private readonly ApplicationDbContext _context;

       
        public CreateModel(IMakinaServices services, ApplicationDbContext context, IModeletServices modeletServices, IMarkaServices markaServices, IWebHostEnvironment ihostingEnvironment)
        {
            _modeletServices = modeletServices;
            _markatServices = markaServices;
            _context = context;
            _services = services;
            this.ihostingEnvironment = ihostingEnvironment;
        }
        public Makina Makina { get; set; }
        public IFormFile Photo { get; set; }
        public string MarkaId { get; set; }
        public string ModelId { get; set; }  
        [FromBody]
        public SelectList MarkaListdll { get; set; }

        public IActionResult OnGet()
        {
            MarkaListdll = new SelectList(_markatServices.GetMarkat(), nameof(Marka.MarkaId),
                            nameof(Marka.MarkaEmer));
            return Page();
        }
        public JsonResult OnGetSubCategories()
        {
            return new JsonResult(_modeletServices.GetModels(MarkaId));
        }

        public async Task<IActionResult> OnPost ()
        {
            if (Makina != null)
            {
                var path = Path.Combine(ihostingEnvironment.WebRootPath, "images", Photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await Photo.CopyToAsync(stream);
                Makina.ImageName = Photo.FileName;
                Makina.MarkaId = MarkaId;
                Makina.ModeliId = ModelId;
                await _services.AddMakinat(Makina);
                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");
        }
    }
}
