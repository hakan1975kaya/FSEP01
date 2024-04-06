using Business.Abstract;
using Entities.Concrete.Dtos.General.Auth;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : Controller
    {
        private IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var dataResult = await _authService.Login(loginDto);
            if (dataResult.Success)
            {
                if (dataResult.Data != null)
                {
                    return Ok(dataResult);
                }
            }
            return BadRequest(dataResult);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var dataResult = await _authService.Register(registerDto);
            if (dataResult.Success)
            {
                if (dataResult.Data != null)
                {
                    return Ok(dataResult);
                }
            }
            return BadRequest(dataResult);
        }



    }
}
