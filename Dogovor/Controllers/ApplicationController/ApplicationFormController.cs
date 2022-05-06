using Entity.DataTransfer_s.FormApplication;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.FormToFillService;

namespace Dogovor.Controllers.ApplicationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IFormService _formService;
        private readonly IWebHostEnvironment _environment;

        public ApplicationFormController(IFormService formService, IWebHostEnvironment environment)
        {
            _formService = formService;
            _environment = environment;
        }
        [HttpPost("DocumentFirstPage")]
        public async Task<IActionResult> DocumentFirstPage(DocumentDTO dto)
        {
            var message = await _formService.InsertIntoDocument(dto);
            if(!message.Contains(200.ToString()))
                return BadRequest(message);
            else return Ok(message);
        }
        [HttpPost("PrincipalSecondPage")]
        public async Task<IActionResult> PrincipalSecondPage(PrincipalInfoDTO dto)
        {
            var message = await _formService.InsertIntoPrincopalInfo(dto);
            if (!message.Contains(200.ToString()))
                return BadRequest(message);
            else return Ok(message);
        }
        [HttpPost("ReceiversInfoThirdPage")]
        public async Task<IActionResult> ReceiverThirdPage(ReceiversInfoDTO dto)
        {
            var message = await _formService.InsertReceiversInfoId(dto);
            if (!message.Contains(200.ToString()))
                return BadRequest(message);
            else return Ok(message);
        }
        [HttpPost("PurposePageFour")]
        public async Task<IActionResult> PurposePageFour(PurposeDTO dto)
        {
            var message = await _formService.InsertIntoPurposeId(dto);
            if (!message.Contains(200.ToString()))
                return BadRequest(message);
            else return Ok(message);
        }
        [HttpPost("ValidationPageFive")]
        public async Task<IActionResult> ValidationPageFive(ValidationDataDTO dto)
        {
            var message = await _formService.InsertIntoValidatonDatas(dto);
            if (!message.Contains(200.ToString()))
                return BadRequest(message);
            else return Ok(message);
        }
        [HttpGet("GenerateFile")]
        public async Task<IActionResult> FileValue([FromQuery]int OrderId)
        {
            var Path = _environment.WebRootPath;
            var finalPath = await _formService.OrderInfo(OrderId, Path);
            var fileName = finalPath.Split("\\").Last().Trim();
            return File(await System.IO.File.ReadAllBytesAsync(finalPath), "application/octet-stream", fileName);
        }
    }
}
