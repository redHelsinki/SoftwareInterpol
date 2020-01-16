using System;
using System.Collections.Generic;
using System.Text;

namespace Interpol.DAL.Models {
    public class Instigator {
        public int Id { get; set; }
        public int FileId { get; set; }
        public int FactionId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
