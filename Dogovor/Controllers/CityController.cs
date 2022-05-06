using Entity.DataTransfer_s.City;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpPost("InsertCity")]
        public async Task<IActionResult> InsertCity(CityDTO dto)
        {
            var city = await _cityService.InsertCity(dto);
            if (city.Contains("200"))
                return Ok(city);
            return BadRequest(city);
        }
        [HttpPut("UpdateCity")]
        public async Task<IActionResult> UpdateCity(City city)
        {
            var message = await _cityService.UpdateCity(city);
            if (message.Contains("200"))
                return Ok(message);
            return BadRequest(message);
        }
        [HttpGet("CitiesList")]
        public async Task<IActionResult> CityList()
        {
            return Ok(await _cityService.GetCities());
        }
        [HttpGet("GetCityById")]
        public async Task<IActionResult> GetCityById(int Id)
        {
            var message = await _cityService.GetCitybyId(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
        [HttpDelete("CityDeleteById")]
        public async Task<IActionResult> Delete(int Id)
        {
            var message = await _cityService.DeleteCity(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
    }
}
