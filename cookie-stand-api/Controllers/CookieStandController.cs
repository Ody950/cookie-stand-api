
using Microsoft.AspNetCore.Mvc;
using cookie_stand_api.Models;
using cookie_stand_api.Models.DTOs;
using cookie_stand_api.Models.Interfaces;


namespace cookie_stand_api.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CookieStandsController : ControllerBase
        {
            private readonly ICookieStand _cookieStandService;


            public CookieStandsController(ICookieStand cookieStandService)
            {
                _cookieStandService = cookieStandService;
            }

            // GET: api/CookieStands
            [HttpGet]
            public async Task<ActionResult<IEnumerable<CookieStand2DTO>>> GetCookieStands()
            {
                var cookieStands = await _cookieStandService.GetAll();
                return Ok(cookieStands);
            }

            // GET: api/CookieStands/5
            [HttpGet("{id}")]
            public async Task<ActionResult<CookieStand2DTO>> GetCookieStand(int id)
            {
                var cookieStand = await _cookieStandService.GetById(id);

                if (cookieStand == null)
                {
                    return NotFound();
                }

                return Ok(cookieStand);
            }

            // PUT: api/CookieStands/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCookieStand(int id, CookieStandDTO toupdatecookieStand)
            {

                var cookieStand = await _cookieStandService.Update(id, toupdatecookieStand);

                if (cookieStand == null)
                {
                    return NotFound();
                }
                return Ok(cookieStand);
            }



            // POST: api/CookieStands

            [HttpPost]
            public async Task<ActionResult<CookieStand>> PostCookieStand(CookieStandDTO cookieStand)
            {
                await _cookieStandService.Create(cookieStand);
                return Ok();
            }

            // DELETE: api/CookieStands/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCookieStand(int id)
            {
                _cookieStandService.Delete(id);
                return NoContent();
            }


        }
    }