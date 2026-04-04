using Microsoft.AspNetCore.Mvc;
using VagabondAPI.Models;
using VagabondAPI.Services;

namespace VagabondAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController(IDestinationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var destinations = await _service.GetAllAsync();
            return Ok(destinations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var destination = await _service.GetByIdAsync(id);
            return Ok(destination);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Destination destination)
        {
            await _service.AddAsync(destination);
            return CreatedAtAction(nameof(Get), new { id = destination.Id }, destination);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Destination destination)
        {
            if (id != destination.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(destination);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
