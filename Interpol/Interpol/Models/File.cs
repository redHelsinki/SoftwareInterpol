using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interpol.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactionId { get; set; } // fk
        public int DangerousnessId { get; set; } // fk
        public string Notes { get; set; }

    }
}
