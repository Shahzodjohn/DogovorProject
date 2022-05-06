using Entity.DataTransfer_s;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.PrincipalName;

namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalNameController : ControllerBase
    {
        private readonly IPrincipalNameService _nameService;

        public PrincipalNameController(IPrincipalNameService nameService)
        {
            _nameService = nameService;
        }

        [HttpPost("InsertPrincipalName")]
        public async Task<IActionResult> InsertPrincipalName(PrincipalNameDTO dto)
        {
            var city = await _nameService.InsertPrincipalName(dto);
            if (city.Contains("200"))
                return Ok(city);
            return BadRequest(city);
        }
        [HttpPut("PrincipalNameUpdate")]
        public async Task<IActionResult> PrincipalNameUpdate(PrincipalName place)
        {
            var message = await _nameService.PrincipalNameUpdate(place);
            if (message.Contains("200"))
                return Ok(message);
            return BadRequest(message);
        }
        [HttpGet("PrincipalNameList")]
        public async Task<IActionResult> PrincipalNameList()
        {
            return Ok(await _nameService.PrincipalNameList());
        }
        [HttpGet("GetPrincipalNameById")]
        public async Task<IActionResult> GetPrincipalNameById(int Id)
        {
            var message = await _nameService.GetPrincipalNameById(Id);
            if (message == null)
                return BadRequest("Error! Entities are null!");
            return Ok(message);
        }
        [HttpDelete("DeletePrincipalName")]
        public async Task<IActionResult> DeletePrincipalName(int Id)
        {
            var message = await _nameService.DeletePrincipalName(Id);
            if (message == null)
                return BadRequest("Error! Entities are null!");
            return Ok(message);
        }
    }
}
