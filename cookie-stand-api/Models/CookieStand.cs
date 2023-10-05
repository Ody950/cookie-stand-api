using cookie_stand_api.Models.Interfaces;

namespace cookie_stand_api.Models
{
    public class CookieStand
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public double AverageCookiesPerSale { get; set; }
        public string? Owner { get; set; }

        // Navigation Proparites
        public List<HourlySale> hourlySale { get; set; }

    }
}
