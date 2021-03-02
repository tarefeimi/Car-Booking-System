using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;

namespace RentalRazorPages.Pages.MakinaPages
{
    [Authorize(Roles = "Admin")]
    [BindProperties(SupportsGet = true)]
    public class EditModel : PageModel
    {
        private readonly IMakinaServices _services;
        private readonly IModeletServices _modeletServices;
        private readonly IMarkaServices _markatServices;
        private readonly IWebHostEnvironment hostingEnvironment;
        public EditModel(IMakinaServices services, IModeletServices modeletServices, IMarkaServices markaServices, IWebHostEnvironment hostingEnvironment)
        {
            _modeletServices = modeletServices;
            _markatServices = markaServices;
            _services = services;
            this.hostingEnvironment = hostingEnvironment;
        }

        public Makina Makina { get; set; }

        public IFormFile Photo { get; set; }

        public List<SelectListItem> Markat { get; set; }

        public List<SelectListItem> Modelet { get; set; }

        public IActionResult OnGet(Guid id)
        {

            Markat = _markatServices.GetMarkat().Select(x => new SelectListItem {
                Text =x.MarkaEmer,
                Value = x.MarkaId
            })
                .ToList();

            Modelet = _modeletServices.GetModelet().Select(x => new SelectListItem
            {   
                Text = x.ModeliEmer,
                Value = x.ModeliId
            })
            .ToList();
            Makina = _services.GetMakina(id);

            if (Makina == null)
            {
                return NotFound();
            }
            return Page();
        }
        public  IActionResult OnPost()
        {
            if (this.Makina.ImageName != null)
            {
                var path1 = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/images", Makina.ImageName);
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1);
                }       
            }
            var path = Path.Combine(hostingEnvironment.WebRootPath, "images", Photo.FileName);
            var stream = new FileStream(path, FileMode.Create);
            Photo.CopyToAsync(stream);
            Makina.ImageName = Photo.FileName;
            _services.UpdateMakina(Makina);
            return RedirectToPage("Index");
        }
    }
}


     