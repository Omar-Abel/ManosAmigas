using ManosAmigas_Back.Sources.Application.Interfaces.Services;
using ManosAmigas_Back.Sources.Application.ViewModels.Registrations;
using ManosAmigas_Back.Sources.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManosAmigas_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;
        public RegistrationController(IRegistrationService registrationServic)
        {
            _service = registrationServic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetAll()
        {
            var volunteers = await _service.GetAllViewModel();
            return Ok(volunteers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationViewModel>> GetById(int id)
        {
            var registrations = await _service.GetByIdSaveViewModel(id);
            if (registrations == null)
            {
                return NotFound();
            }
            return Ok(registrations);
        }

        [HttpPost]
        public async Task<ActionResult> Add(SaveRegistrationViewModel registrations)
        {
            await _service.Add(registrations);
            return CreatedAtAction(nameof(GetById), new { id = registrations.Id }, registrations);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SaveRegistrationViewModel registrations)
        {
            if (id != registrations.Id)
            {
                return BadRequest("The ID in the URL does not match the ID in the model.");
            }
            await _service.Update(registrations);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingRegistrations = await _service.GetByIdSaveViewModel(id);
            if (existingRegistrations == null)
            {
                return NotFound();
            }

            await _service.Delete(id);
            return NoContent();
        }
    }
}
