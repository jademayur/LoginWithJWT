using LoginWithJWT.DTOs;
using LoginWithJWT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // Endpoint to register a new user
        [HttpPost]
        public async Task<IActionResult> AddUser(RegisterRequestDto request)
        {
            await _userService.AddAsync(request);
            return Ok("User registered successfully");
        }
    }
}
