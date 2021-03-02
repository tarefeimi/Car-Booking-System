using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Models
{
    public class Modeli
    {
        [Key]
        [Required]
        [Display(Name = "Car Model  ")]
        public string ModeliId { get; set; }
        [Required(ErrorMessage ="Car Model Name Is Required !")]
        [Display(Name = "Car Model Name ")]
        public string ModeliEmer { get; set; }

        [Required]
        [Display(Name = "Car Make  ")]
        public string MarkaId { get; set; }
        public Marka Marka { get; set; }
    }
}
