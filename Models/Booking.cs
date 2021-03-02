using RentalRazorPages.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Models
{
    public class Booking
    {
        [Key]
        public Guid BookingId { get; set; }
        [Display(Name = "Date From ")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Date To  ")]
        public DateTime DateTo { get; set; }
        [Display(Name = "Pick-Up Location ")]
        public string PickUpLocation { get; set; }
        [Display(Name ="Return Location ")]
        public string ReturnLocation { get; set; }
        public Guid MakinaId { get; set; }
        public Makina Makina { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserEmail { get; set; }
    }
}
