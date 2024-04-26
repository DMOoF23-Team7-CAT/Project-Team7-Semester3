using Rally.Application.Dto.Base;

namespace Rally.Application.Dto.Category
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;

    }
}