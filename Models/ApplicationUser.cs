using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentalRazorPages.Models
{
    public class ApplicationUser : IdentityUser
    {
        public static ClaimsIdentity Identity { get; internal set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public List<Booking> Bookings { get; set; }
        [NotMapped]
        public object UserEmail { get; internal set; }
    }
}
