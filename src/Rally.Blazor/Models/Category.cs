using System.ComponentModel.DataAnnotations;

namespace Rally.Blazor.Models;

public class Category
{
    private int _id;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "ID must be greater than 0.")]
    public int Id
    {
        get => _id;
        set => _id = value;
    }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string Rules { get; set; } = string.Empty;

    // Non-mapped property for handling string input
    [Required(ErrorMessage = "ID is required.")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "ID must be a positive number.")]
    public string IdAsString
    {
        get => _id.ToString();
        set
        {
            if (int.TryParse(value, out var result) && result > 0)
            {
                _id = result;
            }
            else
            {
                throw new ValidationException("Invalid ID value.");
            }
        }
    }
}

