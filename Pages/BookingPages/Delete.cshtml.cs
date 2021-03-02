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
using RentalRazorPages.Services;

namespace RentalRazorPages.Pages.BookingPages
{
    [Authorize(Roles = "Admin")]
    [BindProperties(SupportsGet = true)]
    public class DeleteModel : PageModel
    {
        private readonly IBookingServices _services;

        public DeleteModel(IBookingServices services)
        {
            _services = services;
        }
        public Booking Booking { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(Guid id)
        {
            _services.DeleteBooking(id);
            return RedirectToPage("Index");
        }
    }
}
