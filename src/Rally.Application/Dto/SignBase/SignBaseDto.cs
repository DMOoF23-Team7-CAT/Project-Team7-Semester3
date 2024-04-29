using Rally.Application.Dto.Base;

namespace Rally.Application.Dto.SignBase
{
    public class SignBaseDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
        public byte[] Image { get; set; } = new byte[0];

    }
}