using Entity.DataTransfer_s;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiversPassportTypeController : ControllerBase
    {
        private readonly IReceiversPassportTypeService _typeService;

        public ReceiversPassportTypeController(IReceiversPassportTypeService typeService)
        {
            _typeService = typeService;
        }
        [HttpPost("InsertReceiversPassportType")]
        public async Task<IActionResult> InsertReceiversPassportType(ReceiversPassportTypeDTO dto)
        {
            var city = await _typeService.InsertReceiversPassportType(dto);
            if (city.Contains("200"))
                return Ok(city);
            return BadRequest(city);
        }
        [HttpPut("ReceiversPassportTypeUpdate")]
        public async Task<IActionResult> ReceiversPassportTypeUpdate(ReceiversPassportType type)
        {
            var message = await _typeService.ReceiversPassportTypeUpdate(type);
            if (message.Contains("200"))
                return Ok(message);
            return BadRequest(message);
        }
        [HttpGet("ReceiversPassportTypeList")]
        public async Task<IActionResult> ReceiversPassportTypeList()
        {
            return Ok(await _typeService.ReceiversPassportTypeList());
        }
        [HttpGet("GetReceiversPassportTypeById")]
        public async Task<IActionResult> GetReceiversPassportTypeById(int Id)
        {
            var message = await _typeService.GetReceiversPassportTypeById(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
        [HttpDelete("DeleteReceiversPassportType")]
        public async Task<IActionResult> DeleteReceiversPassportType(int Id)
        {
            var message = await _typeService.DeleteReceiversPassportType(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
    }
}
