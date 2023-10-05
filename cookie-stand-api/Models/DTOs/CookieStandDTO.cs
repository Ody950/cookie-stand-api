namespace cookie_stand_api.Models.DTOs
{
    public class CookieStandDTO
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int MinimumCustomersPerHour { get; set; }
        public int MaximumCustomersPerHour { get; set; }
        public decimal AverageCookiesPerSale { get; set; }
        public string Owner { get; set; }

    }
}
