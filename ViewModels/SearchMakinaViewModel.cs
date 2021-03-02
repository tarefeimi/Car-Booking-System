using RentalRazorPages.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.ViewModels
{
    public class SearchMakinaViewModel
    {

        [DateLessThan("DateTo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date From ")]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Date To  ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateTo { get; set; }

        [Required]
        [Display(Name = "Pick-Up Location ")]
        public string PickUpLocation { get; set; }
        [Display(Name = "Return Location ")]
        public string ReturnLocation { get; set; }
        public IList<Makina> Makina { get; set; } = new List<Makina>();
        public Makina MakinaId { get; set; }
    }
}
