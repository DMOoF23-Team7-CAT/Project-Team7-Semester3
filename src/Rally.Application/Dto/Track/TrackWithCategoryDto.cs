using Rally.Application.Dto.Category;

namespace Rally.Application.Dto.Track
{
    public class TrackWithCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public CategoryDto? Category { get; set; }
    }
}

