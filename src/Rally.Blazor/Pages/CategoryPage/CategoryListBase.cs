using Microsoft.AspNetCore.Components;
using Rally.Blazor.Models;
using Rally.Blazor.Services.Interfaces;
using System.Collections.Generic;

namespace Rally.Blazor.Pages.CategoryPage;

public class CategoryListBase : ComponentBase
{
    [Inject]
    public ICategoryService CategoryService { get; set; }

    public IEnumerable<Category> Categories { get; set; } = new List<Category>();

    protected override async Task OnInitializedAsync()
    {
        var categories = await CategoryService.GetAll();
        if (categories != null)
        {
            Categories = categories;
        }
    }
}

