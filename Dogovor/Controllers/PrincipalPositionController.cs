using Entity.DataTransfer_s;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.PrincipalPosition;

namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalPositionController : ControllerBase
    {
        private readonly IPrincipalPositionService _service;

        public PrincipalPositionController(IPrincipalPositionService service)
        {
            _service = service;
        }
        [HttpPost("InsertPrincipalPosition")]
        public async Task<IActionResult> InsertPrincipalPosition(PrincipalPositionDTO dto)
        {
            var city = await _service.InsertPrincipalPosition(dto);
            if (city.Contains("200"))
                return Ok(city);
            return BadRequest(city);
        }
        [HttpPut("PrincipalPositionUpdate")]
        public async Task<IActionResult> PrincipalPositionUpdate(PrincipalPosition position)
        {
            var message = await _service.PrincipalPositionUpdate(position);
            if (message.Contains("200"))
                return Ok(message);
            return BadRequest(message);
        }
        [HttpGet("PrincipalPositionList")]
        public async Task<IActionResult> PrincipalPositionList()
        {
            return Ok(await _service.PrincipalPositionList());
        }
        [HttpGet("GetPrincipalPositionById")]
        public async Task<IActionResult> GetPrincipalPositionById(int Id)
        {
            var message = await _service.GetPrincipalPositionById(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
        [HttpDelete("DeletePrincipalPosition")]
        public async Task<IActionResult> DeletePrincipalPosition(int Id)
        {
            var message = await _service.DeletePrincipalPosition(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
    }
}
