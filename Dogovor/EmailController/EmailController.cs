using ConnectionProvider;
using Entity.DataTransfer_s.MailRequestDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.MailService;
//using Microsoft.Office.Interop.Word;


namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;

        public EmailController(IWebHostEnvironment environment, IMailService mailService)
        {
            _environment = environment;
            _mailService = mailService;
        }

        [HttpPost("SendEmail")]
        public async Task SendEmail([FromForm]Maildto mailRequest)
        {
            var path = GetPath();
            await _mailService.SendEmailAsync(mailRequest, path);
        }
        private string GetPath()
        {
            var path = _environment.WebRootPath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
    }
}
