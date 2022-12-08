using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalVolunteer.Shared.Models
{
    public class Filter
    {
        public DateTime? Date { get; set; }
        public string? Area { get; set; }
        public int? VolunteersNeeded { get; set; }
        public int? Priority { get; set; }
        public bool? Locked { get; set; }
    }
}
