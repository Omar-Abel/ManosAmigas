namespace ManosAmigas_Back.Sources.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; } // Organizer or Volunteer


        //Navegation Property
        public ICollection<VolunteerActivity> VolunteerActivities { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
