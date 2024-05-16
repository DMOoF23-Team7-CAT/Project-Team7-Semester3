using Microsoft.AspNetCore.Components;
using Rally.Blazor.Models;
using Rally.Blazor.Services.Interfaces;
using System.Threading.Tasks;

namespace Rally.Blazor.Pages.CategoryPage;

public class DeleteCategoryBase : ComponentBase
{
    [Inject]
    public ICategoryService? CategoryService { get; set; }

    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    [Parameter]
    public int Id { get; set; }

    public Category? Category { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Category = await CategoryService!.GetById(Id);
    }

    protected async Task DeleteCategory()
    {
        if (Category != null)
        {
            await CategoryService!.Delete(Category.Id);
            NavigationManager!.NavigateTo("/categories");
        }
    }
}

