using RentalRazorPages.Models;
using RentalRazorPages.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace RentalRazorPages.Services
{
    public interface IBookingServices
    {
        Task<Booking> UpdateBooking(Booking updatedBookings);
        Booking GetBookingById(Guid id);
      //  Task<Booking> AddBooking(SearchMakinaViewModel vm, Guid id); //Guid Id, DateTime dateFrom, DateTime dateTo);

        Task<Booking> AddBooking(Booking booking); //Guid Id, DateTime dateFrom, DateTime dateTo);

        IEnumerable<Booking> GetAllBookings();
        Booking DeleteBooking(Guid id);

        // Task<Booking> AddBookingById(Booking booking);

    }
}