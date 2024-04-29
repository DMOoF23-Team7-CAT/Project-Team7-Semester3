using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rally.Application.Dto.Equipment
{
    public class EquipmentWithoutIdDto
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
    }
}