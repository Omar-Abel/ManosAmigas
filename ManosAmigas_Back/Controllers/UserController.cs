using ManosAmigas_Back.Sources.Application.Interfaces.Services;
using ManosAmigas_Back.Sources.Application.ViewModels.Users;
using ManosAmigas_Back.Sources.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManosAmigas_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAllViewModel();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            var user = await _userService.GetByIdSaveViewModel(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Add(SaveUserViewModel user)
        {
            await _userService.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SaveUserViewModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _userService.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingUser = await _userService.GetByIdSaveViewModel(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.Delete(id);
            return NoContent();
        }
    }
}
