
namespace Rally.Application.Dto.Sign
{
    public class SignWithoutIdDto
    {
        public int SignNumber { get; set; }
        public string XCoordinate { get; set; } = string.Empty;
        public string YCoordinate { get; set; } = string.Empty;
        public string Rotation { get; set; } = string.Empty;
        public int SignBaseId { get; set; }
        public int TrackId { get; set; }
    }
}

