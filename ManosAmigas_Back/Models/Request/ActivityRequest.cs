using System.ComponentModel.DataAnnotations;

namespace ManosAmigas_Back.Models.Request
{
    public class ActivityRequest
    {
  
        [Required] public string title { get; set; } = null!;
        [Required] public string description { get; set; } = null!;
        [Required] public string category { get; set; } = null!;
        [Required] public string location { get; set; } = null!;
        [Required] public string meetingPoint { get; set; } = null!;
        [Required] public int peopleRequired { get; set; }
        [Required] public string benefits {  get; set; } = null!;
        [Required] public DateTime startDate { get; set; }
        [Required] public DateTime endDate { get; set; }
        [Required] public IFormFile image { get; set; } = null!;
        [Required] public int hostId { get; set; }
    }
}
