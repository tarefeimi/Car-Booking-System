using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Models
{
    public class Marka
    {
        [Key]
        [Display(Name = "Car Make Id ")]
        public string MarkaId { get; set; }
        [Required]
        [Display(Name = "Car Make Name ")]
        public string MarkaEmer { get; set; }
        public List<Modeli> Modelet { get; set; }

        public static implicit operator string(Marka v)
        {
            throw new NotImplementedException();
        }
    }
}
