using System;
using System.Collections.Generic;
using System.Text;

namespace Interpol.DAL.Models {
    public class Danger {
        public int Id { get; set; }
        public int Label { get; set; }
        public int Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
