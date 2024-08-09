using ManosAmigas_Back.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ManosAmigas_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpGet("send/{email}")]
        public async Task<IActionResult> SendEmail(string email)
        {
            Response response = new Response();

            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("elvis.antonio.nunez.30@gmail.com", "shksjksuylnkounw"), // Cambia esto por tus credenciales
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("elvis.antonio.nunez.30@gmail.com"),
                    Subject = "MANOS AMIGAS: Inscripción a la actividad",
                    Body = "Te has inscrito a la actividad exitosamente.",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);

                response.success = 1;
                response.message = "Correo enviado correctamente";
                response.Data = email;
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
