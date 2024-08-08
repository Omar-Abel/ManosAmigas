namespace ManosAmigas_Back.Models.Response
{
    public class UserResponse
    {
        public long id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; } = null!;
        public string token { get; set; } = null!;
        public int accountType { get; set; } 
    }
}
