using Rally.Application.Dto.Base;

namespace Rally.Application.Dto.Equipment
{
    public class EquipmentDto : BaseDto
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

    }
}