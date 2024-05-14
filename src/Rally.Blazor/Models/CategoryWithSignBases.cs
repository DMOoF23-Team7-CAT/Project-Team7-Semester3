namespace Rally.Blazor.Models;

public class CategoryWithSignBases : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Rules { get; set; } = string.Empty;

    //public ICollection<SignBaseDto> SignBases { get; set; } = new List<SignBaseDto>();
}