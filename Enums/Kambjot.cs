using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Models.Enums
{
    public enum Kambjot
    {
        [Display(Name ="Manual ")]
        Manuale,
        [Display(Name = "Automatic  ")]
        Automatike,
        [Display(Name = "Tronic  ")]
        Tronik,
    }
}