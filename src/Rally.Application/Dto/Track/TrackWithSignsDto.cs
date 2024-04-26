using Rally.Application.Dto.Base;
using Rally.Application.Dto.Sign;

namespace Rally.Application.Dto.Track
{
    public class TrackWithSignsDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<SignDto> Signs { get; set; } = new List<SignDto>();
    }
}

