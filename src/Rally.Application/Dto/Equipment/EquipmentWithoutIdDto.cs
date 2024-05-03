
namespace Rally.Application.Dto.Equipment
{
    public class EquipmentWithoutIdDto
    {
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public int EquipmentBaseId { get; set; }
    }
}