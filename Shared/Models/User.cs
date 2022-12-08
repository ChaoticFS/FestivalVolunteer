using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalVolunteer.Shared.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Experience { get; set; }
        public bool IsActive { get; set; }
        public int GroupId { get; set; }
    }
}
