﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interpol.Models
{
    public class Locality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Nation { get; set; }
        public string Risk { get; set; }
    }
}
