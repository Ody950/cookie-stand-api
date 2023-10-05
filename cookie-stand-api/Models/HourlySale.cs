using cookie_stand_api.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace cookie_stand_api.Models
{
    public class HourlySale
    {
        public int Id { get; set; }
        public int StandCookieId { get; set; }
        public int salesvalue { get; set; }

        public CookieStand cookieStand { get; set; }
    }
}
