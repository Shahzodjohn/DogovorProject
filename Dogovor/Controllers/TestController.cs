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
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IMailService _mailService;

        public TestController(IMailService mailService, AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _mailService = mailService;
            _context = context;
            _environment = webHostEnvironment;
        }

        [HttpPost("Index")]
        public async Task Index([FromForm]Maildto mailRequest)
        {
            var path = GetPath("Files");
            await _mailService.SendEmailAsync(mailRequest, path.Result);
        }
        private async Task<string> GetPath(string Folder)
        {
            var path = _environment.WebRootPath + $"\\{Folder}";

            if (!Directory.Exists(path))    
            {
                Directory.CreateDirectory(path);
            }
            return path;

        }


    }
}
