
using Rally.Application.Dto.Category;
using Rally.Application.Dto.Sign;

namespace Rally.Application.Dto.Track
{
    public class TrackWithCategorySigns
    {
        public string Name { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<SignWithEquipmentSignBase> Signs { get; set; } = new List<SignWithEquipmentSignBase>();
        public CategoryDto? Category { get; set; }
    }
}