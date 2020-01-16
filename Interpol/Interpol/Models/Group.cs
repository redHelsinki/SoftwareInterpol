using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interpol.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
