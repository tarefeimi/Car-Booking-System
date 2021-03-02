using Microsoft.AspNetCore.Http;
using RentalRazorPages.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.ViewModels
{
    public class MakinaShfaqViewModel
    {
        public List<Makina> Makina { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
