using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.Dtos.AuthsDtos;
using Twitter.Business.Services.Interfaces;

namespace TwitFriday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService {  get; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult>CreateUser(RegisterDto dto)
        {
            await _userService.CreateAsync(dto);
            return Ok();
        }
    }
}
