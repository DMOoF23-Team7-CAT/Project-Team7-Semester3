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

    public async Task<Category> Create(Category dto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/categories", dto);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to create category: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Category>() 
                ?? throw new Exception("Failed to create category");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating category: {ex.Message}", ex);
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/categories/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to delete category: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error deleting category: {ex.Message}", ex);
        }
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/categories");
            if (!response.IsSuccessStatusCode)
            {
                return new List<Category>(); // Return an empty list instead of null
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>() 
                ?? throw new Exception("Failed to retrieve categories");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving all categories: {ex.Message}", ex);
        }
    }

    public async Task<Category> GetById(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/categories/{id}");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null!;

                throw new HttpRequestException($"Failed to get category by ID: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Category>() 
                ?? throw new Exception("Failed to retrieve category by ID");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving category by ID: {ex.Message}", ex);
        }
    }

    public async Task<CategoryWithSignBases> GetCategoryWithSignBases(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/categories/{id}/details");
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null!;

                throw new HttpRequestException($"Failed to get category with sign bases: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<CategoryWithSignBases>()
                ?? throw new Exception("Failed to retrieve category with sign bases");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error retrieving category with sign bases: {ex.Message}", ex);
        }
    }

    public async Task Update(Category dto, int id)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/categories/{id}", dto);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to update category: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error updating category: {ex.Message}", ex);
        }
    }
}

