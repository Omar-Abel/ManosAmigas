using ManosAmigas_Back.Sources.Application.Interfaces.Services;
using ManosAmigas_Back.Sources.Application.ViewModels.VolunteerActivities;
using ManosAmigas_Back.Sources.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManosAmigas_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerActivityController : ControllerBase
    {
        private readonly IVolunteerActivityService _repository;
        public VolunteerActivityController(IVolunteerActivityService volunteerActivityRepository)
        {
            _repository = volunteerActivityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VolunteerActivity>>> GetAll()
        {
            var volunteers = await _repository.GetAllViewModel();
            return Ok(volunteers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VolunteerActivityViewModel>> GetById(int id)
        {
            var volunteers = await _repository.GetByIdSaveViewModel(id);
            if (volunteers == null)
            {
                return NotFound();
            }
            return Ok(volunteers);
        }

        [HttpPost]
        public async Task<ActionResult> Add(SaveVolunteerActivityViewModel volunteers)
        {
            await _repository.Add(volunteers);
            return CreatedAtAction(nameof(GetById), new { id = volunteers.Id }, volunteers);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SaveVolunteerActivityViewModel volunteers)
        {
            if (id != volunteers.Id)
            {
                return BadRequest("The ID in the URL does not match the ID in the model.");
            }
            await _repository.Update(volunteers);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingVolunteers = await _repository.GetByIdSaveViewModel(id);
            if (existingVolunteers == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }
    }
}
