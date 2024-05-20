using System.ComponentModel.DataAnnotations;

namespace Rally.Blazor.Models;

public class Category
{
    private int _id;
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
                _id = -1; // Set to an invalid default that can be checked in validation
            }
        }
    }
}

