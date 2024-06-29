namespace ManosAmigas_Back.Sources.Application.ViewModels.Registrations
{
    public class SaveRegistrationViewModel
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
    }
}
