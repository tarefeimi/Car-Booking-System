using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalRazorPages.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalRazorPages.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Marka> Markat { get; set; }
        public DbSet<Makina> Makinat { get; set; }
        public DbSet<Modeli> Modelet { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Marka>().ToTable("Markat");
            modelBuilder.Entity<Modeli>().ToTable("Modelet");
            modelBuilder.Entity<Makina>().ToTable("Makinat");
            modelBuilder.Entity<Marka>().HasData(
                new Marka
                {
                    MarkaId = "Benz",
                    MarkaEmer = "Mercedes-benz"
                },
                new Marka
                {
                    MarkaId = "Toyota",
                    MarkaEmer = "Toyota"
                },
                new Marka
                {
                    MarkaId = "Ford",
                    MarkaEmer = "Ford"
                });
            modelBuilder.Entity<Modeli>().HasData(

                new Modeli
                {
                    MarkaId = "Benz",
                    ModeliId = "A",
                    ModeliEmer = "A-class"
                },
                new Modeli
                {
                    MarkaId = "Toyota",
                    ModeliId = "Yaris",
                    ModeliEmer = "Yaris"
                },
                new Modeli
                {
                    MarkaId = "Ford",
                    ModeliId = "Focus",
                    ModeliEmer = "Focus"
                });
        }
    }
}
