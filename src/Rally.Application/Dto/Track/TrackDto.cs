using Rally.Application.Dto.Base;

namespace Rally.Application.Dto.Track
{
    public class TrackDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
    }
}