using Entity.DataTransfer_s;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.PrincipalReasonService;

namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalReasonController : ControllerBase
    {
        private readonly IPrincipalReasonService _principalReasonService;

        public PrincipalReasonController(IPrincipalReasonService principalReasonService)
        {
            _principalReasonService = principalReasonService;
        }
        [HttpPost("InsertPrincipalReason")]
        public async Task<IActionResult> InsertPrincipalReason(PrincipalReasonDTO dto)
        {
            var city = await _principalReasonService.InsertPrincipalReason(dto);
            if (city.Contains("200"))
                return Ok(city);
            return BadRequest(city);
        }
        [HttpPut("PrincipalReasonUpdate")]
        public async Task<IActionResult> PrincipalReasonUpdate(PrincipalReason position)
        {
            var message = await _principalReasonService.PrincipalReasonUpdate(position);
            if (message.Contains("200"))
                return Ok(message);
            return BadRequest(message);
        }
        [HttpGet("PrincipalPositionList")]
        public async Task<IActionResult> PrincipalPositionList()
        {
            return Ok(await _principalReasonService.PrincipalReasonList());
        }
        [HttpGet("GetPrincipalReasonById")]
        public async Task<IActionResult> GetPrincipalReasonById(int Id)
        {
            var message = await _principalReasonService.GetPrincipalReasonById(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
        [HttpDelete("PrincipalReasonDelete")]
        public async Task<IActionResult> PrincipalReasonDelete(int Id)
        {
            var message = await _principalReasonService.PrincipalReasonDelete(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
    }
}
