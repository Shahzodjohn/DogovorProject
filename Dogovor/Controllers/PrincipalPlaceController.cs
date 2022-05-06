using Entity.DataTransfer_s;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.PrincipalPlaceService;

namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalPlaceController : ControllerBase
    {
        private readonly IPrincipalPlaceService _placeService;

        public PrincipalPlaceController(IPrincipalPlaceService placeService)
        {
            _placeService = placeService;
        }
        [HttpPost("InsertPrincipalPlace")]
        public async Task<IActionResult> InsertPrincipalPlace(PrincipalPlaceDTO dto)
        {
            var city = await _placeService.InsertPrincipalPlace(dto);
            if (city.Contains("200"))
                return Ok(city);
            return BadRequest(city);
        }
        [HttpPut("PrincipalPlaceUpdate")]
        public async Task<IActionResult> PrincipalPlaceUpdate(PrincipalPlace place)
        {
            var message = await _placeService.PrincipalPlaceUpdate(place);
            if (message.Contains("200"))
                return Ok(message);
            return BadRequest(message);
        }
        [HttpGet("PrincipalPlaceList")]
        public async Task<IActionResult> PrincipalPlaceList()
        {
            return Ok(await _placeService.PrincipalPlaceList());
        }
        [HttpGet("GetPrincipalPlaceById")]
        public async Task<IActionResult> GetPrincipalPlaceById(int Id)
        {
            var message = await _placeService.GetPrincipalPlaceById(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
        [HttpDelete("DeletePrincipalPlace")]
        public async Task<IActionResult> DeletePrincipalPlace(int Id)
        {
            var message = await _placeService.DeletePrincipalPlace(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
    }
}
