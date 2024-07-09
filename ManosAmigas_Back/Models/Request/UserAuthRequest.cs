using System.ComponentModel.DataAnnotations;

namespace ManosAmigas_Back.Models.Request
{
    public class UserAuthRequest
    {
        [Required]
        public string email { get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;
    }
}
