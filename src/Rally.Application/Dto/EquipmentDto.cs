using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto.EquipmentBase;

namespace Rally.Application.Dto.Equipment
{
    public class EquipmentDto
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public EquipmentBaseDto? EquipmentBase { get; private set; }

        public EquipmentDto(string xCoordinate, string yCoordinate, string rotation, EquipmentBaseDto equipmentBase)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Rotation = rotation;
            EquipmentBase = equipmentBase;
        }
    }
}