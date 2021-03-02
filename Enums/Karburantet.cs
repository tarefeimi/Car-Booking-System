using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Models.Enums
{
    public enum Karburantet
    {
        [Display(Name = "Fuel ")]
        Benzine,
        [Display(Name = "Gasoline ")]
        Nafte,
        [Display(Name = "Hybrid  ")]
        Elektrike,
    }
}