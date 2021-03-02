using RentalRazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.ViewModels
{
    public class BookingsAndCustomerViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
