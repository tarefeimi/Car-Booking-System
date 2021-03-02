using Microsoft.AspNetCore.Mvc.Rendering;
using RentalRazorPages.Models;
using RentalRazorPages.Pages.ModeliPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalRazorPages.Repositories
{
    public interface IModeletServices
    {
        IEnumerable<Modeli> GetModelet();

        IEnumerable<Modeli> GetModels(string MarkaId);
        void DeleteModelet(string id);
        Task<Modeli> AddModele(Modeli modeli);
        Modeli UpdateModelet(Modeli updatedModeli);
        Modeli GetModeli(string Id);
    }
}