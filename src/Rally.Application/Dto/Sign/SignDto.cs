using Rally.Application.Dto.Base;

namespace Rally.Application.Dto.Sign
{
    public class SignDto : BaseDto
    {
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;

    }
}