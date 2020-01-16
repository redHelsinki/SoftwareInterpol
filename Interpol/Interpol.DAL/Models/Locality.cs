using System;
using System.Collections.Generic;
using System.Text;

namespace Interpol.DAL.Models {
    public class Locality {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoordX { get; set; }
        public string CoordY { get; set; }
        public string Nation { get; set; }
        public int Risk { get; set; }
        public bool IsDeleted { get; set; }
    }
}
