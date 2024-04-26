using Rally.Application.Dto.Base;
using Rally.Application.Dto.EquipmentBase;

namespace Rally.Application.Dto.SignBase
{
    public class SignBaseWithEquipmentBaseDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; } = new byte[0];
        public EquipmentBaseDto? EquipmentBase { get; set; }
    }
}