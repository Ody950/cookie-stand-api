using cookie_stand_api.Models.DTOs;

namespace cookie_stand_api.Models.Interfaces
{
    public interface ICookieStand
    {
        
        Task Create(CookieStandDTO cookieStand);

        Task<IEnumerable<CookieStand2DTO>> GetAll();

        Task<CookieStand2DTO> GetById(int id);

        Task Delete(int id);

        Task<CookieStand> Update(int id, CookieStandDTO updatedCookieStand);

    }
}
