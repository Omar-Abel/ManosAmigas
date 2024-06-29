namespace ManosAmigas_Back.Sources.Application.ViewModels.VolunteerActivities
{
    public class VolunteerActivityViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Locations { get; set; }
        public string Tasks { get; set; }
        public string Benefits { get; set; }
        public int OrganizerId { get; set; }
    }
}
