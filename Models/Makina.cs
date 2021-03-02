using Microsoft.AspNetCore.Http;
using RentalRazorPages.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Models
{
    public class Makina
    {
        [Key]
        public Guid MakinaId { get; set; }


        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Car")]
        public string MakinaEmer { get; set; }


        [Required]
        [Display(Name = "Car Id")]
        public string MarkaId { get; set; }


        public Marka Marka { get; set; }


        [Display(Name = "Car Model Id")]
        public string ModeliId { get; set; }

        public Modeli Modeli { get; set; }
        [Display(Name = "Transmission ")]
        [Required(ErrorMessage = "Transmission is required!")]
        public Kambjot Kambjo { get; set; }
        [Display(Name = "Fuel ")]

        public Karburantet Karburanti { get; set; }
        [Display(Name = "Car Power ")]

        public string FuqiaMotorrike { get; set; }

        [Display(Name = "Production Year")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime VitiProdhimit { get; set; }
        [Required]
        [Display(Name = "Car Image")]

        public string ImageName { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
