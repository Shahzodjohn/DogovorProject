using Entity.DataTransfer_s;
using Entity.DataTransfer_s.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using System.Net;
using System.Security.Claims;

namespace DogovorProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            logger.LogInformation("created homeController");
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var returnMessage = await _userService.RegisterUser(dto);
            if(returnMessage.Contains("400"))
                return BadRequest(returnMessage);
            else
                return Ok(returnMessage);        
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthorizationDTO dto)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            var returnMessage = await _userService.Login(dto);
            if(returnMessage.Contains("400"))
                return BadRequest(returnMessage);
            return Ok("Json web token = " + returnMessage);
        }
        [HttpGet("CurrentUser")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CurrentUser()
        {
            var claim = User.Identity as ClaimsIdentity;
            if (claim == null) return BadRequest(400);
            var userInfo = await _userService.UsersInformation(claim); 
            return Ok(userInfo);
        }
    }
}
