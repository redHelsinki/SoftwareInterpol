using System;
using System.Collections.Generic;
using System.Text;

namespace Interpol.DAL.Models {
    public class File {
        public int Id { get; set; }
        public int Name { get; set; }
        public int FactionId { get; set; }
        public int DangerId { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }

    }
}
