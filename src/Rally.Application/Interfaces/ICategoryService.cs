using Rally.Application.Dto.Category;
using Rally.Application.Interfaces.Base;
using Rally.Core.Entities;

namespace Rally.Application.Interfaces
{
    public interface ICategoryService : IService<CategoryDto, Category, CategoryWithoutIdDto>
    {
        Task<CategoryWithSignBasesDto> GetCategoryWithSignBases(int categoryId);
    }
}

