using cookie_stand_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace cookie_stand_api.Data
{
    public class SalmonDbContext : DbContext
    {
        public SalmonDbContext(DbContextOptions Options) : base(Options)
        {

        }


        public DbSet<CookieStand> CookieStands { get; set; }

        public DbSet<HourlySale> hourlySale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            var cookieStands = new List<CookieStand>
        {
            new CookieStand
            {
                Id=1,
                Location = "a",
                Description = "d1",
                MinimumCustomersPerHour = 11,
                MaximumCustomersPerHour = 22,
                AverageCookiesPerSale = 5.5,
                Owner = "1"
            },
            new CookieStand
            {
                Id=2,
                Location = "b",
                Description = "d2",
                MinimumCustomersPerHour = 22,
                MaximumCustomersPerHour = 44,
                AverageCookiesPerSale = 5.5,
                Owner = "2"
            }
        };

            // Add the data to the context
            modelBuilder.Entity<CookieStand>().HasData(cookieStands);

            modelBuilder.Entity<CookieStand>()
     .HasKey(c => c.Id);
        }



    }
}