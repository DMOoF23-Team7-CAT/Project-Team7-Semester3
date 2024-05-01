using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Sign : Entity
    {
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

        public SignBase? SignBase { get; set; }
        public int SignBaseId { get; set; }
        public Track? Track { get; set; }
        public int TrackId { get; set; }
    }
}

