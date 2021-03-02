using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentalRazorPages.Data;
using RentalRazorPages.Models;

namespace RentalRazorPages.Pages.Users
{
    public class UserBookingsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UserBookingsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Booking> Bookings;
        public ActionResult OnGet(string id)
        {
            Bookings = _context.Bookings.Where(b => b.UserId == id).ToList();
            return Page();
        }
    }
}
