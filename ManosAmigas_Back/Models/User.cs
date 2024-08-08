using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ManosAmigas_Back.Models
{
    public partial class User
    {
        public User() {
            Activities = new HashSet<Activity>();
        }

        [Key]
        public long Id { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; } = null!;

        [StringLength(350)]
        [Unicode(false)]
        public string Password { get; set; } = null!;

        public int AccountType { get; set; }

        [InverseProperty("Host")]
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
