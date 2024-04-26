using Rally.Application.Dto.Base;
using Rally.Application.Dto.EquipmentBase;

namespace Rally.Application.Dto.Equipment
{
    public class EquipmentWithEquipmentBaseDto : BaseDto
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public EquipmentBaseDto? EquipmentBase { get; set; }
    }
}

