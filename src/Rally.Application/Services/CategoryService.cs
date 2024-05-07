using Rally.Application.Dto.Category;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories is null)
                throw new ApplicationException("Categories could not be found.");

            var mappedCategories = ObjectMapper.Mapper.Map<IEnumerable<CategoryDto>>(categories);
            if (mappedCategories is null)
                throw new ApplicationException("Categories could not be mapped.");
            
            return mappedCategories;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
                throw new ApplicationException("Category could not be found.");
            
            var mappedCategory = ObjectMapper.Mapper.Map<CategoryDto>(category);
            if (mappedCategory is null)
                throw new ApplicationException("Category could not be mapped.");
            
            return mappedCategory;
        }

        public Task<CategoryDto> Create(CategoryDto dto)
        {
            //FIXME - Validate if id exists
            if (dto.Id <= 1)
            {
                throw new ApplicationException("Category Id must be greater than 0.");
            }
            else
            {
                return Task.FromResult(dto);
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryWithSignBasesDto> GetCategoryWithSignBases(int categoryId)
        {
            var entity = await _categoryRepository.GetCategoryWithSignBasesAsync(categoryId);

            var mappedEntity = ObjectMapper.Mapper.Map<CategoryWithSignBasesDto>(entity);
            if (mappedEntity is null)
                throw new ApplicationException("Category with SignBases could not be mapped.");

            return mappedEntity;
        }


    }
}

