using ManosAmigas_Back.Models.Request;
using ManosAmigas_Back.Models.Response;
using ManosAmigas_Back.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;

namespace ManosAmigas_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> AunthenticateUser([FromBody] UserAuthRequest model)
        {
            Response response = new();
            var uResponse = await _userService.AuthUser(model);

            if (uResponse != null)
            {
                response.success = 0;
                response.message = "Usuario o contraseña incorrecta";
                return Ok(response);
            }

            response.success = 1;
            response.message = "Usuario logueado correctamente";
            response.Data = uResponse;

            return Ok(response);

        }
    }
}
