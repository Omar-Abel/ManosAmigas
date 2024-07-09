using System.ComponentModel.DataAnnotations;

namespace ManosAmigas_Back.Models.Request
{
    public class UserRegisterRequest
    {
        [Required] public string firstName { get; set; } = null!;
        [Required] public string lastName { get; set; } = null!;
        [Required] public string email { get; set; } = null!;
        [Required] public string password { get; set; } = null!;
    }
}
