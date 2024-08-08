namespace ManosAmigas_Back.Models.Response
{
    public class ActivityResponse
    {
        public int id {  get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string location { get; set; }
        public string meetingPoint  { get; set; }
        public int peopleRequired { get; set; }
        public string benefits { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string imagePath { get; set; }
        public int hostId { get; set; }



    }
}
