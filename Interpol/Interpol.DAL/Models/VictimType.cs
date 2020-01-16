using System;
using System.Collections.Generic;
using System.Text;

namespace Interpol.DAL.Models {
    public class VictimType {
        public int Id { get; set; }
        public string Label { get; set; }
        public bool IsDeleted { get; set; }
    }
}
