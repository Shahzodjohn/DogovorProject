using ConnectionProvider;
using Entity.DataTransfer_s.MailRequestDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.MailService;
//using Microsoft.Office.Interop.Word;
using Task = System.Threading.Tasks.Task;

namespace Dogovor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMailService _mailService;


        public TestController(AppDbContext context, IWebHostEnvironment webHostEnvironment, IMailService mailService)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _mailService = mailService;
        }
        [HttpPost("Index")]
        public async Task Index([FromForm]Maildto mailRequest)
        {
           await _mailService.SendEmailAsync(mailRequest);
        }



    }
}
