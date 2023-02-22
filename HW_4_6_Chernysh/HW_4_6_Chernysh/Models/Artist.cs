using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Chernysh.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramUrl { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

    }
}
