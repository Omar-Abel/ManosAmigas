using ManosAmigas_Back.Models.Request;
using ManosAmigas_Back.Models.Response;
using ManosAmigas_Back.Services.Activities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManosAmigas_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("Activities")]
        public async Task<IActionResult> GetAllActivities()
        {
            Response response = new();
            response.Data = await _activityService.GetActivities();

            if (response.Data == null)
            {
                response.success = 0;
                response.message = "No se encontraron peliculas";
                return BadRequest(response);
            }

            response.success = 1;
            response.message = "Peliculas encontradas";
            return Ok(response);
        }

        [HttpGet("Images")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllActivitiesImages(string imagePath)
        {
            byte[] imageBytes = await System.IO.File.ReadAllBytesAsync(imagePath);
            return File(imageBytes, "image/jpeg");
        }

        [HttpGet("Activity{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            Response response = new();
            response.Data = await _activityService.GetActivityById(id);

            if (response.Data == null)
            {
                response.success = 0;
                response.message = "Pelicula no encontrada";
                return BadRequest(response);
            }

            response.success = 1;
            response.message = "pelicula encontrada";
            return Ok(response);

        }

        [HttpPost("addActivity")]
        public async Task<IActionResult> PostActivity([FromForm] ActivityRequest model)
        {
            Response response = new();

            response.Data = await _activityService.CreateActivity(model);

            if (response.Data == null)
            {
                response.success = 0;
                response.message = "No se pudo agregar la actividad";
                return BadRequest(response);
            }

            response.success = 1;
            response.message = "Actividad agregada";
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            Response response = new();
            response.Data = await _activityService.DeleteActivity(id);

            if (response.Data == null)
            {
                response.success = 0;
                response.message = "No se pudo eliminar la actividad";
                return BadRequest(response);
            }

            response.success = 1;
            response.message = "Actividad eliminada correctamente";
            return Ok(response);
        }
    }
}
