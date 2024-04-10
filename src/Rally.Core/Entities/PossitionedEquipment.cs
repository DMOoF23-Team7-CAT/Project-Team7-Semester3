using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class PositionedEquipment : Entity
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set;} = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public Equipment? Equipment{ get; set; }
    }
}