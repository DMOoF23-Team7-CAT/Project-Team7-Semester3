using Rally.Application.Dto.Category;

namespace Rally.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task<CategoryDto> Create(CategoryDto dto);
        Task Update(CategoryDto dto);
        Task Delete(int id);
        Task<CategoryWithSignBasesDto> GetCategoryWithSignBases(int categoryId);
    }
}

