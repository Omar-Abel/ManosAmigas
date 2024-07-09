using System.ComponentModel.DataAnnotations;

namespace ManosAmigas_Back.Models.Response
{
    public class UserRegisterResponse
    {
        [Required] public string firstName { get; set; } = null!;
        [Required] public string lastName { get; set; } = null!;
        [Required] public string email { get; set; } = null!;
    }
}
