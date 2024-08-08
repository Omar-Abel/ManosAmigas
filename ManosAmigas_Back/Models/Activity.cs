using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ManosAmigas_Back.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(750)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Category { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Location { get; set; } = null!;

        [Required]
        public string MeetingPoint { get; set; } = null!;

        [Required]
        public int PeopleRequired { get; set; }

        [Required]
        [StringLength(300)]
        public string Benefits { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string ImagePath { get; set; } = null!;

        [Required]
        public long HostId { get; set; }

        // Relación con User
        [ForeignKey("HostId")]
        [InverseProperty("Activities")]
        [JsonIgnore]
        public User Host { get; set; }
    }
}
