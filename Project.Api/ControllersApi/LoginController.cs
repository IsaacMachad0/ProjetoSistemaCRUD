using Microsoft.AspNetCore.Mvc;
using Project.Application.DTOs;
using Project.Application.Services.Interfaces;

namespace Project.Api.ControllersApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult PostLogin([FromForm] LoginDTO loginDTO)
        {
            var result = _service.LoginUser(loginDTO);

            if (!result)
            {
                return BadRequest(result);
            }

        
            return Ok(result);
        }
    }
}
