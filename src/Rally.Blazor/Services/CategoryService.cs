using Rally.Blazor.Models;
using Rally.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Collections.Generic;

namespace Rally.Blazor.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Category> Create(Category dto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        var response = await _httpClient.GetAsync("api/categories");
        if (!response.IsSuccessStatusCode)
        {
            return new List<Category>(); // Return an empty list instead of null
        }

        return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>() ?? new List<Category>();
    }

    public Task<Category> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryWithSignBases> GetCategoryWithSignBases(int Id)
    {
        throw new NotImplementedException();
    }

    public Task Update(Category dto, int id)
    {
        throw new NotImplementedException();
    }
}

