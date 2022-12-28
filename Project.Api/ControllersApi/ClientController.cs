using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Project.Application.DTOs;
using Project.Application.Services.Interfaces;
using Project.Domain.Entities;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;
        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient([FromForm] ClientDTO clientDTO)
        {
            var result = await _service.CreateClientAsync(clientDTO);
            
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetClientsAsync()
        {
            var result = await _service.GetClientsAsync();
            if (result.IsSucess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdClientAsync(int id)
        {
            var result = await _service.GetByIdClientAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditClientAsync([FromForm] ClientDTO clientDTO)
        {
            var result = await _service.EditClientAsync(clientDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteClientAsync(int id)
        {
            var result = await _service.DeleteClientAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
