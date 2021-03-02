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
using RentalRazorPages.Services;

namespace RentalRazorPages.Pages.BookingPages
{
    [Authorize(Roles = "Admin")]
    [BindProperties(SupportsGet = true)]
    public class EditModel : PageModel
    {
        private readonly IBookingServices _services ;
        private readonly IMakinaServices _makinaServices;

        public EditModel(IBookingServices services, IMakinaServices makinaServices)
        {
            _services = services;
            _makinaServices = makinaServices;
        }

        public Booking Booking { get; set; }
        public List<SelectListItem> Makina { get; set; }
        public IActionResult OnGet(Guid id)
        {

            Makina = _makinaServices.GetMakinat().Select(x => new SelectListItem
            {
                Text = x.MakinaEmer,
                Value = x.MakinaEmer
            })
            .ToList();
            Booking = _services.GetBookingById(id);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            _services.UpdateBooking(Booking);
            return RedirectToPage("Index");
        }

    }
}
