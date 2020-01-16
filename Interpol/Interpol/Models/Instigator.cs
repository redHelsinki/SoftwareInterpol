using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interpol.Models
{
    public class Instigator
    {
        public int Id { get; set; }
        public int FactionId { get; set; } // fk
    }
}
