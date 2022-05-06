using Entity.DataTransfer_s;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Purpose;

namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurposeController : ControllerBase
    {
        private readonly IPurposeService _purpose;

        public PurposeController(IPurposeService purpose)
        {
            _purpose = purpose;
        }
        [HttpPost("InsertPurpose")]
        public async Task<IActionResult> InsertPurpose([FromBody] PurposeModelDTO dto)
        {
            var message = await _purpose.InsertPurpose(dto);
            if (message.Contains("200"))
                return Ok(message);
            return BadRequest(message);
        }
        [HttpPut("PurposeUpdate")]
        public async Task<IActionResult> PurposeUpdate(Purpose position)
        {
            var message = await _purpose.PurposeUpdate(position);
            if (message.Contains("200"))
                return Ok(message);
            return BadRequest(message);
        }
        [HttpGet("PurposeList")]
        public async Task<IActionResult> PurposeList()
        {
            return Ok(await _purpose.PurposeList());
        }
        [HttpGet("GetPurposeById")]
        public async Task<IActionResult> GetPurposeById(int Id)
        {
            var message = await _purpose.GetPurposeById(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
        [HttpDelete("PurposeDelete")]
        public async Task<IActionResult> PurposeDelete(int Id)
        {
            var message = await _purpose.PurposeDelete(Id);
            if (message == null)
                return BadRequest("not found");
            return Ok(message);
        }
    }
}
