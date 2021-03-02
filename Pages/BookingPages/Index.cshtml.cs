using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Services;
using RentalRazorPages.ViewModels;

namespace RentalRazorPages.Pages.BookingPages
{
    [Authorize]
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        private readonly IBookingServices _services;
        private ApplicationDbContext _context;
        public IndexModel(IBookingServices services,  ApplicationDbContext context)
        {
            _services = services;
            _context = context;
        }
        public BookingsAndCustomerViewModel bookingsAndCustomer { get; set; }

        public async Task<IActionResult> OnGet(string userId = null, string userEmail = null)
        {

            if (userId == null )
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var claimEmail = claimsIdentity.FindFirst(ClaimTypes.Email);
                userId = claim.Value;
                userEmail = claimEmail.Value;
            }

            if (User.IsInRole("Admin"))
            {
                bookingsAndCustomer = new BookingsAndCustomerViewModel()
                {
                    Bookings = await _context.Bookings.Include(a=>a.Makina).ToListAsync(),
                    UserObj = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.Email == userEmail)
                };
            }
            else
            {
                bookingsAndCustomer = new BookingsAndCustomerViewModel()
                {
                    Bookings = await _context.Bookings.Include(a=>a.Makina).Where(c => c.UserId == userId).ToListAsync(),
                    UserObj = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.Id == userId)
                };
            }
            return Page();
        }
    }
}
