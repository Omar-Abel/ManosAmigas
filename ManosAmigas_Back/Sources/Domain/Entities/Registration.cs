namespace ManosAmigas_Back.Sources.Domain.Entities
{
    public class Registration
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }

        //Navegation Property
        public int UserId { get; set; }
        public User User { get; set; }

        public int ActivityId { get; set; }
        public VolunteerActivity Activity { get; set; }
    }
}
