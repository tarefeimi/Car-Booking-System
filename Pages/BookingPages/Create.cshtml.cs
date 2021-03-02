using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using RentalRazorPages.Data;
using RentalRazorPages.Models;
using RentalRazorPages.Repositories;
using RentalRazorPages.Services;
using RentalRazorPages.ViewModels;

namespace RentalRazorPages.Pages.BookingPages
{
    [BindProperties(SupportsGet = true)]
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IBookingServices _services;
        private readonly IMakinaServices _makinaServices;
        private readonly ApplicationDbContext _context;

        public CreateModel(IBookingServices services, IMakinaServices makinaServices, ApplicationDbContext dbContext)
        {
            _services = services;
            _makinaServices = makinaServices;
            _context = dbContext;
        }

        public SearchMakinaViewModel vm { get; set; }
        public List<Makina> Makina { get; set; }
        public Booking Booking { get; set; }
        public bool ReturnCheckBox { get;set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
          if (ReturnCheckBox==true){
                 vm.ReturnLocation = vm.PickUpLocation;}  
            Makina = _makinaServices.Availability(vm);
            return Page();
        }

        public async Task<IActionResult> OnPostMakina(Guid id, string userId, string userEmail)
        {
            Makina = _makinaServices.AvailabilityId(vm,id);
            if (vm.Makina.Count==1)
            {
                if (userId == null)
                {
                    var claimsIdentity = (ClaimsIdentity)User.Identity;
                    var claimId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                    var claimEmail = claimsIdentity.FindFirst(ClaimTypes.Email);
                    userId = claimId.Value;
                    userEmail = claimEmail.Value;

                }
                if (ModelState.IsValid)
                {            
                    Booking.DateFrom = vm.DateFrom;
                    Booking.DateTo = vm.DateTo;
                    Booking.PickUpLocation = vm.PickUpLocation;
                    Booking.ReturnLocation = vm.ReturnLocation;
                    Booking.UserId = userId;
                    Booking.MakinaId = id;
                    Booking.UserEmail = userEmail;
                    Booking = await _services.AddBooking(Booking);
                }
                

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Name", "Email"));
                message.To.Add(new MailboxAddress("Client ", userEmail));
                message.Subject = "Thank you for the order ";
                message.Body = new TextPart("plain")
                {
                    Text = "Thank you for renting " + Booking.Makina.ModeliId + " between dates :"
                    + Booking.DateFrom + " to :" + Booking.DateTo + " Please Get the Car on "
                    + Booking.PickUpLocation + "And Drop the car In " + Booking.ReturnLocation
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("YourEmail", "YourPass");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return RedirectToPage("index");
            }
            return NotFound();
            //}
            //return RedirectToPage("Error");
        }
    }
}


