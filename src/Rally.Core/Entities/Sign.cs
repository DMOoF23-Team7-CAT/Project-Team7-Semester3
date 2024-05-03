using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("SignBase")]
        public int SignBaseId { get; set; }
        public Track? Track { get; set; }
        [ForeignKey("Track")]
        public int TrackId { get; set; }
    }
}

