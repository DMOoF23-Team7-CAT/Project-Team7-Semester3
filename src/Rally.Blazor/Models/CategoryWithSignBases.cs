using System.ComponentModel.DataAnnotations;

namespace Rally.Blazor.Models;

public class CategoryWithSignBases
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string Rules { get; set; } = string.Empty;

    //public ICollection<SignBaseDto> SignBases { get; set; } = new List<SignBaseDto>();
}