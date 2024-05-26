using Microsoft.AspNetCore.Components;
using Rally.Blazor.Models;
using Rally.Blazor.Services.Interfaces;
using System.Threading.Tasks;

namespace Rally.Blazor.Pages.CategoryPage;

public class UpdateCategoryBase : ComponentBase
{
    [Inject]
    public ICategoryService? CategoryService { get; set; }
    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    [Parameter]
    public int Id { get; set; }

    public Category Category { get; set; } = new Category();

    public string? UpdateStatusMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Category = await CategoryService!.GetById(Id) ?? new Category();
    }

    protected async Task HandleValidSubmit()
    {
        try
        {
            await CategoryService!.Update(Category);
            UpdateStatusMessage = "Category updated successfully!";
            StateHasChanged();

            await Task.Delay(1000);
            NavigationManager!.NavigateTo("/categories");
        }
        catch (Exception ex)
        {
            UpdateStatusMessage = $"Error updating category: {ex.Message}";
            StateHasChanged();
        }
    }
}
