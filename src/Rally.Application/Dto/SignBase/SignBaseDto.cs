using Rally.Application.Dto.Base;

namespace Rally.Application.Dto.SignBase
{
    public class SignBaseDto : BaseDto
    {
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

    }
}