using Microsoft.AspNetCore.Mvc;
using Project.Application.DTOs;
using Project.Application.Services.Interfaces;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromForm] UserDTO userDTO)
        {
            var result = await _service.CreateUserAsync(userDTO);

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetUsersAsync()
        {
            var result = await _service.GetUsersAsync();
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdUserAsync(int id)
        {
            var result = await _service.GetByIdUserAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditUserAsync([FromForm] UserDTO userDTO)
        {
            var result = await _service.EditUserAsync(userDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            var result = await _service.DeleteUserAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
