using System;
using System.Collections.Generic;
using System.Text;

namespace Interpol.DAL.Models {
    public class Faction {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
