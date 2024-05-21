using Microsoft.AspNetCore.Components;
using Rally.Blazor.Models;
using Rally.Blazor.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Rally.Blazor.Pages.CategoryPage;

public class CreateCategoryBase : ComponentBase
{
    [Inject]
    public ICategoryService? CategoryService { get; set; }

    public Category Category { get; set; } = new Category();

    public string? CreateStatusMessage { get; set; }

    protected async Task HandleValidSubmit()
    {
        try
        {
            await CategoryService!.Create(Category);
            CreateStatusMessage = "Category created successfully!";
            Category = new Category(); // Reset the form
        }
        catch (ValidationException vex)
        {
            CreateStatusMessage = $"Validation error: {vex.Message}";
        }
        catch (Exception ex)
        {
            CreateStatusMessage = $"Error creating category: {ex.Message}";
        }
    }
}
