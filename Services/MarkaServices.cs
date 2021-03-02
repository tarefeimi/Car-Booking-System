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
    public class MarkaServices : IMarkaServices
    {
        private readonly ApplicationDbContext _context;
        public MarkaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Marka> GetMarkat()
        {
            var markat = _context.Markat.ToList();
            return markat;
        }

        public  void DeleteMarkat(string id)
        {
            var a =  _context.Markat.FirstOrDefault(x => x.MarkaId == id);

            if (a != null)
            {
                _context.Markat.Remove(a);
                _context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }

        }
        public async Task<Marka> AddMarka(Marka marka)
        {
            await _context.Markat.AddAsync(marka);
            await _context.SaveChangesAsync();
            return marka;
        }
        public Marka GetMarka(string Id)
        {
            var marka = _context.Markat
                .Include(a => a.Modelet)
                .FirstOrDefault(x=>x.MarkaId==Id);
            return marka;
        }
        public Marka UpdateMarkat(Marka updatedMarka)
        {
            var marka = _context.Markat.FirstOrDefault(x => x.MarkaId == updatedMarka.MarkaId);
            if (marka!=null)
            {
                marka.MarkaEmer = updatedMarka.MarkaEmer;
                _context.SaveChanges();
            }
            return marka;
        }
    }
}

