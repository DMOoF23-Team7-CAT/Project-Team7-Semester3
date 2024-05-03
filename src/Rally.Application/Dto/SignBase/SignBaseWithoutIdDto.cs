
namespace Rally.Application.Dto.SignBase
{
    public class SignBaseWithoutIdDto
    {
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; } = new byte[0];
        public int CategoryId { get; set; }
        public int EquipmentBaseId { get; set; }
    }
}