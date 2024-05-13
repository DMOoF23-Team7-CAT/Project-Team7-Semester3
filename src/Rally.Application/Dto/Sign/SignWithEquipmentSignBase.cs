using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Equipment;
using Rally.Application.Dto.SignBase;

namespace Rally.Application.Dto.Sign
{
    public class SignWithEquipmentSignBase
    {
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public SignBaseDto? SignBase { get; set; }
        public EquipmentWithEquipmentBaseDto? Equipment { get; set; }
    }
}

