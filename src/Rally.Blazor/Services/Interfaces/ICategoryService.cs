using Rally.Blazor.Models;

namespace Rally.Blazor.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int id);
    Task<Category> Create(Category dto);
    Task Update(Category dto, int id);
    Task Delete(int id);
    Task<CategoryWithSignBases> GetCategoryWithSignBases(int Id);
}