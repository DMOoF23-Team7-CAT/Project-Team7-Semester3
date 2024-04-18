using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto;
using Rally.Application.Interfaces;
using Rally.Application.Mapper;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class CategoryService : Service<CategoryDto, Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // NOTE: Methods are implemented in the base class with validation and potential logging.

        public async Task<IEnumerable<CategoryDto>> GetCategoryWithExercises(int categoriesId)
        {
            var entities = await _categoryRepository.GetCategoryWithExercisesAsync(categoriesId);
            if (entities is null)
                throw new ApplicationException("Entities could not be found.");

            var mappedEntities = ObjectMapper.Mapper.Map<IEnumerable<CategoryDto>>(entities);
            if (mappedEntities is null)
                throw new ApplicationException("Entities could not be mapped.");

            return mappedEntities;
        }
    }
}

