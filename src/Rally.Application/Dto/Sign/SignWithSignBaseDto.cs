using Rally.Application.Dto.Base;
using Rally.Application.Dto.SignBase;

namespace Rally.Application.Dto.Sign
{
    public class SignWithSignBaseDto : BaseDto
    {
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

        public SignBaseDto? SignBase { get; set; }
    }
}

