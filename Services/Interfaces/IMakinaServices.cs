using RentalRazorPages.Models;
using RentalRazorPages.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Repositories
{
    public interface IMakinaServices 
    {
       Makina GetMakina(Guid id);
       Makina DeleteMakinat(Guid id);
       Task <Makina> AddMakinat(Makina makina);
       Task<Makina> UpdateMakina(Makina updatedMakina);
       IEnumerable<Makina> GetMakinat();
       List<Makina> Availability(SearchMakinaViewModel vm);
       List<Makina> AvailabilityId(SearchMakinaViewModel vm, Guid id);
    }
}
