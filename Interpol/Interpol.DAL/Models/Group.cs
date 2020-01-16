using System;
using System.Collections.Generic;
using System.Text;

namespace Interpol.DAL.Models {
    public class Group {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
