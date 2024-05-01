using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities.Base;

namespace Rally.Core.Entities
{
    public class Equipment : Entity
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public EquipmentBase? EquipmentBase { get; set; }
        public int EquipmentBaseId { get; set; }
    }
}

