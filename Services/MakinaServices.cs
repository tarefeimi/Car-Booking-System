using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Repositories
{
    public class MakinaServices : IMakinaServices
    {
        private readonly ApplicationDbContext _context;
        public MakinaServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public  List<Makina> Availability(SearchMakinaViewModel vm)
        {                

            var carsBooked = from b in _context.Bookings
                             where
                             ((vm.DateFrom >= b.DateFrom) && (vm.DateFrom <= b.DateTo)) ||
                             ((vm.DateTo >= b.DateFrom) && (vm.DateTo <= b.DateTo)) ||
                             ((vm.DateFrom <= b.DateFrom) && (vm.DateTo >= b.DateFrom)) && (vm.DateTo <= b.DateTo) ||
                             ((vm.DateFrom >= b.DateFrom) && (vm.DateFrom <= b.DateTo)) && (vm.DateTo >= b.DateTo) ||
                             ((vm.DateFrom <= b.DateFrom) && (vm.DateTo >= b.DateTo))
                             select b;

            var availableMakina = _context.Makinat.Where(r => !carsBooked.Any(b => b.MakinaId == r.MakinaId))
                .ToList();

            foreach (var item in availableMakina)
            {
                vm.Makina.Add(item);
            }

            return availableMakina;
        }
        public List<Makina> AvailabilityId(SearchMakinaViewModel vm, Guid id)
        {
            var carsBooked = from b in _context.Bookings
                             where
                             ((vm.DateFrom >= b.DateFrom) && (vm.DateFrom <= b.DateTo)) ||
                             ((vm.DateTo >= b.DateFrom) && (vm.DateTo <= b.DateTo)) ||
                             ((vm.DateFrom <= b.DateFrom) && (vm.DateTo >= b.DateFrom)) && (vm.DateTo <= b.DateTo) ||
                             ((vm.DateFrom >= b.DateFrom) && (vm.DateFrom <= b.DateTo)) && (vm.DateTo >= b.DateTo) ||
                             ((vm.DateFrom <= b.DateFrom) && (vm.DateTo >= b.DateTo))
                             select b;

            var availableMakina = _context.Makinat.Where(r => !carsBooked.Any(b => b.MakinaId == r.MakinaId)).ToList();

            foreach (var item in availableMakina)
            {
                if (item.MakinaId == id)
                {
                    vm.Makina.Add(item);                                
                }
            }
            return availableMakina;
        }
        public async Task<Makina>AddMakinat(Makina makina)
        {
              await  _context.Makinat.AddAsync(makina);
              await   _context.SaveChangesAsync();
                return makina;
        }

        public  Makina DeleteMakinat(Guid id)
        {
            var a = _context.Makinat
                .Include(a => a.Marka)
                .Include(a => a.Modeli)
                .FirstOrDefault(x => x.MakinaId == id);

            if (a != null)
            {
                _context.Makinat.Remove(a);
                _context.SaveChanges();
                return a;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public  Makina GetMakina(Guid id)
        {
            Makina x = _context.Makinat
                .Include(a => a.Marka) 
                .Include(a => a.Modeli)
                .FirstOrDefault(x => x.MakinaId == id);
            return x;
        }
        public IEnumerable<Makina> GetMakinat()
        {
            var makinat =  _context.Makinat.Include(x => x.Marka)
                .Include(x => x.Modeli)
                .ToList();

            return makinat;
        }
        public async Task<Makina> UpdateMakina(Makina updatedMakina)
        {
            var makina = _context.Makinat.FirstOrDefault(x => x.MakinaId == updatedMakina.MakinaId);
            
            if (makina != null)
            {
                makina.MakinaEmer = updatedMakina.MakinaEmer;
                makina.Marka = updatedMakina.Marka;
                makina.Modeli = updatedMakina.Modeli;
                makina.ImageName = updatedMakina.ImageName;
                makina.FuqiaMotorrike = updatedMakina.FuqiaMotorrike;
                makina.Kambjo = updatedMakina.Kambjo;
                makina.Karburanti = updatedMakina.Karburanti;

              await _context.SaveChangesAsync();
            }
            return makina;
        }
    }
}
