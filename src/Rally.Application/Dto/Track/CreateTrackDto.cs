
namespace Rally.Application.Dto.Track
{
    public class CreateTrackDto
    {
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}