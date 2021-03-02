using RentalRazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Repositories
{
    public interface IMarkaServices
    {
        IEnumerable<Marka> GetMarkat();
        Marka GetMarka(string Id);
        void DeleteMarkat(string id);
        Task<Marka> AddMarka(Marka marka);
        Marka UpdateMarkat(Marka updatedMarka);

    }
}
