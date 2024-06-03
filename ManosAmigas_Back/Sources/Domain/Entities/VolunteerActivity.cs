namespace ManosAmigas_Back.Sources.Domain.Entities
{
    public class VolunteerActivity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Locations { get; set; }
        public string Tasks { get; set; }
        public string Benefits { get; set; }

        //Navegation Property

        public int OrganizerId { get; set; }
        public User Organizer { get; set; }


        public ICollection<Registration> Registrations { get; set; }
    }
}
