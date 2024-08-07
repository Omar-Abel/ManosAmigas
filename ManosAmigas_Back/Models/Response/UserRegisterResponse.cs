using System.ComponentModel.DataAnnotations;

namespace ManosAmigas_Back.Models.Response
{
    public class UserRegisterResponse
    {
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public string email { get; set; } = null!;

        public int accountType { get; set; }


    }
}
