using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Core.Entities
{
    public class Sign
    {
        public int Id { get; set; }
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

        public Exercise? Exercise { get; set; }
        public Track? Track { get; set; }
    }
}