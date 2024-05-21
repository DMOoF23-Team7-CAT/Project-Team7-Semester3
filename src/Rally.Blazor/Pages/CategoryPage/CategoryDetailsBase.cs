using Microsoft.AspNetCore.Components;
using Rally.Blazor.Models;
using Rally.Blazor.Services.Interfaces;

namespace Rally.Blazor.Pages.CategoryPage;

public class CategoryDetailsBase : ComponentBase
{
    [Inject]
    public ICategoryService? CategoryService { get; set; }

    [Parameter]
    public int Id { get; set; }

    public Category? Category { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Category = await CategoryService!.GetById(Id);
    }
}