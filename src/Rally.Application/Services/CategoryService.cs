using FluentValidation;
using Rally.Application.Dto.Category;
using Rally.Application.Exceptions;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Validators;
using Rally.Core.Entities;
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

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories is null)
                throw new NotFoundException("Categories could not be found.");

            var mappedCategories = ObjectMapper.Mapper.Map<IEnumerable<CategoryDto>>(categories);
            if (mappedCategories is null)
                throw new MappingException("Categories could not be mapped.");
            
            return mappedCategories;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
                throw new NotFoundException("Category could not be found.");
            
            var mappedCategory = ObjectMapper.Mapper.Map<CategoryDto>(category);
            if (mappedCategory is null)
                throw new MappingException("Category could not be mapped.");
            
            return mappedCategory;
        }

        public async Task<CategoryDto> Create(CategoryDto dto)
        {
            await ValidateIfExist(dto);

            var category = ObjectMapper.Mapper.Map<Category>(dto);
            if (category is null)
                throw new MappingException("Category could not be mapped.");
            
            var validator = new CategoryValidator();
            var validationResult = await validator.ValidateAsync(category);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _categoryRepository.AddAsync(category);

            return ObjectMapper.Mapper.Map<CategoryDto>(category);
        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
                throw new NotFoundException($"Category with ID {id} could not be found.");

            await _categoryRepository.DeleteAsync(category);
        }

        public async Task Update(CategoryDto dto)
        {
            var oldCategory = await _categoryRepository.GetByIdAsync(dto.Id);
            if (oldCategory is null)
                throw new NotFoundException($"Category with ID {dto.Id} could not be found.");

            var newCategory = ObjectMapper.Mapper.Map<Category>(dto);

            var validator = new CategoryValidator();
            var validationResult = await validator.ValidateAsync(newCategory);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            await _categoryRepository.UpdateAsync(ObjectMapper.Mapper.Map(dto, oldCategory));
        }

        public async Task<CategoryWithSignBasesDto> GetCategoryWithSignBases(int categoryId)
        {
            var entity = await _categoryRepository.GetCategoryWithSignBasesAsync(categoryId);

            var mappedEntity = ObjectMapper.Mapper.Map<CategoryWithSignBasesDto>(entity);
            if (mappedEntity is null)
                throw new MappingException("Category with SignBases could not be mapped.");

            return mappedEntity;
        }

        private async Task ValidateIfExist(CategoryDto dto)
        {
            if (dto.Id != 0)
            {
                var existingEntity = await _categoryRepository.GetByIdAsync(dto.Id);
                if (existingEntity != null)
                    throw new NotFoundException($"Category with ID {dto.Id} already exists");
            }
        }
    }
}

