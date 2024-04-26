using Rally.Application.Dto.Base;
using Rally.Application.Dto.SignBase;

namespace Rally.Application.Dto.Category
{
    public class CategoryWithSignBasesDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;

        public ICollection<SignBaseDto> SignBases { get; set; } = new List<SignBaseDto>();
    }
}

