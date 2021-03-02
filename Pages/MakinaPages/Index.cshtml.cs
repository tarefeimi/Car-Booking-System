using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;
using RentalRazorPages.ViewModels;

namespace RentalRazorPages.Pages.MakinaPages
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        private readonly IMakinaServices _services;
        private readonly ApplicationDbContext _db;
        public IndexModel(IMakinaServices services, ApplicationDbContext db)
        {
            _services = services;
            _db = db;
        }
        public IEnumerable<Makina> Makina { get;set; }
        public MakinaShfaqViewModel MakinatViewModel { get; private set; }

        public async Task<IActionResult> OnGet(int productPage = 1, string searchModeli = null, string searchMakinaEmer = null, string searchMarka = null)
        {
            MakinatViewModel = new MakinaShfaqViewModel()
            {
                Makina = await _db.Makinat.ToListAsync()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/MakinaPages?productPage=:");

            param.Append("&searchMakinaEmer=");
            if (searchMakinaEmer != null)
            {
                param.Append(searchMakinaEmer);
            }

            param.Append("&searchModeli=");
            if (searchModeli != null)
            {
                param.Append(searchModeli);
            }

            param.Append("&searchMarka=");
            if (searchMarka != null)
            {
                param.Append(searchMarka);
            }

            if (searchModeli != null)
            {
                MakinatViewModel.Makina = await _db.Makinat.Where(u => u.ModeliId.ToLower().Contains(searchModeli.ToLower())).ToListAsync();
            }
            else
            {
                if (searchMarka != null)
                {
                    MakinatViewModel.Makina = await _db.Makinat.Where(u => u.MarkaId.ToLower().Contains(searchMarka.ToLower())).ToListAsync();
                }
                else
                {
                    if (searchMakinaEmer != null)
                    {
                        MakinatViewModel.Makina = await _db.Makinat.Where(u => u.MakinaEmer.ToLower().Contains(searchMakinaEmer.ToLower())).ToListAsync();
                    }
                }
            }

            var count = MakinatViewModel.Makina.Count;

            MakinatViewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                TotalItems = count,
            };

            MakinatViewModel.Makina = MakinatViewModel.Makina.OrderBy(p => p.MakinaEmer)
                .Skip((productPage - 1)).ToList();

            return Page();
        }
    }
}
