using System;
using System.Collections.Generic;

namespace Rally.Domain.Entity
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