using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interpol.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int VictimId { get; set; }
        public Victim Victim { get; set; }
    }
}
