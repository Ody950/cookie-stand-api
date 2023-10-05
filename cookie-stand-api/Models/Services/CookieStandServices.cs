using cookie_stand_api.Models.DTOs;
using cookie_stand_api.Models.Interfaces;
using cookie_stand_api.Models;
using Microsoft.EntityFrameworkCore;
using cookie_stand_api.Data;
using cookie_stand_api.Models.DTOs;
using cookie_stand_api.Models.Interfaces;
using System.Net;

namespace cookie_stand_api.Models.Services
{
    public class CookieStandService : ICookieStand
    {

        private readonly SalmonDbContext _context;
        public CookieStandService(SalmonDbContext context)
        {
            _context = context;

        }

        public async Task Create(CookieStandDTO cookieStand)
        {
            var cooke = new CookieStand()
            {
                Location = cookieStand.Location,
                Description = cookieStand.Description,
                MinimumCustomersPerHour = cookieStand.MinimumCustomersPerHour,
                MaximumCustomersPerHour = cookieStand.MaximumCustomersPerHour,
                AverageCookiesPerSale = (double)cookieStand.AverageCookiesPerSale,
                Owner = cookieStand.Owner

            };

            await _context.CookieStands.AddAsync(cooke);
            await _context.SaveChangesAsync();

            int max = (int)(cookieStand.MaximumCustomersPerHour * cookieStand.AverageCookiesPerSale);
            int min = (int)(cookieStand.MinimumCustomersPerHour * cookieStand.AverageCookiesPerSale);
            int diff = max - min;

            List<HourlySale> hours = new List<HourlySale>();

            var random = new Random();

            for (int i = 0; i < 14; i++)
            {
                var hourlySale = new HourlySale()
                {
                    StandCookieId = cooke.Id,
                    salesvalue = random.Next(min, max),
                };



                hours.Add(hourlySale);
            }


            cooke.hourlySale = hours;


            await _context.SaveChangesAsync();
            //return cookieStand;
        }

        public async Task Delete(int id)
        {
            var cookieStand = _context.CookieStands.Find(id);


            _context.CookieStands.Remove(cookieStand);


            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CookieStand2DTO>> GetAll()
        {
            var all = await _context.CookieStands
                .Include(c => c.hourlySale)
                .ToListAsync();

            List<CookieStand2DTO> alllist = new List<CookieStand2DTO>();

            foreach (var cookieStand in all)
            {
                var stands = await GetById(cookieStand.Id);

                alllist.Add(stands);
            }

            return alllist;
        }

        public async Task<CookieStand2DTO> GetById(int id)
        {

            var cooke = await _context.CookieStands
                .Include(c => c.hourlySale)
                .FirstOrDefaultAsync(c => c.Id == id);

            var newcooke = new CookieStand2DTO()
            {
                Id = cooke.Id,
                Location = cooke.Location,
                Description = cooke.Description,
                MaximumCustomersPerHour = cooke.MaximumCustomersPerHour,
                MinimumCustomersPerHour = cooke.MinimumCustomersPerHour,
                AverageCookiesPerSale = (decimal)cooke.AverageCookiesPerSale,
                Owner = cooke.Owner,
            };

            List<int> h = new List<int>();

            foreach (var item in cooke.hourlySale)
            {
                h.Add(item.salesvalue);
            }
            newcooke.hourlySale = h;

            return newcooke;

        }

        public async Task<CookieStand> Update(int id, CookieStandDTO updatedCookieStand)
        {
            var cookieStand = await _context.CookieStands
                .Include(c => c.hourlySale)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cookieStand != null)
            {
                cookieStand.Location = updatedCookieStand.Location;
                cookieStand.Description = updatedCookieStand.Description;
                cookieStand.MinimumCustomersPerHour = updatedCookieStand.MinimumCustomersPerHour;
                cookieStand.MaximumCustomersPerHour = updatedCookieStand.MaximumCustomersPerHour;
                cookieStand.AverageCookiesPerSale = (double)updatedCookieStand.AverageCookiesPerSale;
                cookieStand.Owner = updatedCookieStand.Owner;

                int max = (int)(cookieStand.MaximumCustomersPerHour * cookieStand.AverageCookiesPerSale);
                int min = (int)(cookieStand.MinimumCustomersPerHour * cookieStand.AverageCookiesPerSale);
                int diff = max - min;



                var random = new Random();


                foreach (var item in cookieStand.hourlySale)
                {
                    item.salesvalue = random.Next(min, max);
                }




                await _context.SaveChangesAsync();
            }

            return cookieStand;
        }
    }
}