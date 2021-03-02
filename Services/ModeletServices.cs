using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Repositories
{
    public class ModeletServices : IModeletServices
    {
        private readonly ApplicationDbContext _context;


        public ModeletServices(ApplicationDbContext context)
        {   
            _context = context;
        }

        public async Task<Modeli> AddModele(Modeli modeli)
        {
            await _context.Modelet.AddAsync(modeli);
            await _context.SaveChangesAsync();
            return modeli;
        }

        public void DeleteModelet(string id)
        {
            var a  =  _context.Modelet.FirstOrDefault(x => x.ModeliId == id);

            if (a != null)
            {
                _context.Modelet.Remove(a);
                _context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
           
        }
        public IEnumerable<Modeli> GetModelet()
        {
            var modelet =  _context.Modelet;
            return modelet;
        }

        public Modeli GetModeli(string Id)
        {
            var modeli = _context.Modelet.
                 Include(m => m.Marka)
                .FirstOrDefault(x => x.ModeliId == Id);
            return modeli;
        }

        public IEnumerable<Modeli> GetModels(string MarkaId)
        {
            IEnumerable<Modeli> model = _context.Modelet.Where(x => x.MarkaId == MarkaId).ToList();
            return model;
        }

        public Modeli UpdateModelet(Modeli updatedModeli)
        {
           // var modeli = _context.Modelet.FirstOrDefault(x => x.ModeliId == updatedModeli.ModeliId);
            var modeli = _context.Modelet
                .Include(m=>m.Marka)
                .FirstOrDefault(x => x.ModeliId == updatedModeli.ModeliId);

            if (modeli != null)
            {
                modeli.ModeliEmer = updatedModeli.ModeliEmer;
                modeli.MarkaId = updatedModeli.MarkaId;
                _context.SaveChanges();
            }
            return modeli;
        }
    }
}

