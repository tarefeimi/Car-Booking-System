using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalRazorPages.Services
{
    public class BookingServices : IBookingServices
    {
        private readonly ApplicationDbContext _context;
        public BookingServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public Booking GetBookingById(Guid id)
        {
            Booking x = _context.Bookings
                .FirstOrDefault(x => x.BookingId == id);
            return x;
        }
        public async Task<Booking> AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            _context.SaveChanges();
            return booking;
        }
        public Booking DeleteBooking(Guid id)
        {
            var a =  _context.Bookings.FirstOrDefault(x => x.BookingId == id);

            if (a != null)
            {
                _context.Bookings.Remove(a);
                _context.SaveChanges();
                return a;
            }
            else
            {
                throw new NotImplementedException();
            }

        }
        public async Task<Booking> UpdateBooking(Booking updatedBookings)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.BookingId == updatedBookings.BookingId);

            if (booking != null)
            {
                booking.DateFrom = updatedBookings.DateFrom;
                booking.DateTo = updatedBookings.DateTo;
                booking.PickUpLocation = updatedBookings.PickUpLocation;
                booking.ReturnLocation = updatedBookings.ReturnLocation;
                await _context.SaveChangesAsync();
            }
            return booking;
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            var bookings = _context.Bookings.Include(x => x.Makina)
                .ToList();

            return bookings;
        }
    }
}
