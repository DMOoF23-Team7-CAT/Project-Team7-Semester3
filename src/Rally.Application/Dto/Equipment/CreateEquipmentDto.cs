using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.Base;
using Rally.Application.Dto.EquipmentBase;

namespace Rally.Application.Dto.Equipment
{
    public class CreateEquipmentDto : BaseDto
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public EquipmentBaseDto EquipmentBase { get; private set; }

        public CreateEquipmentDto(EquipmentBaseDto equipmentBase)
        {
            EquipmentBase = equipmentBase;
        }
    }
}