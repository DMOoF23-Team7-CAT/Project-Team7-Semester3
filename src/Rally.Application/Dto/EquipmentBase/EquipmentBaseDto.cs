using Rally.Application.Dto.Base;

namespace Rally.Application.Dto.EquipmentBase
{
    public class EquipmentBaseDto : BaseDto
    {
        public byte[] Image { get; set; } = new byte[0];
    }
}