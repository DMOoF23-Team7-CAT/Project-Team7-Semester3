using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories.Base;
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
        //NOTE - Added comments for clarity
        // Instance of the repository for the Category entity. used to access methods not implemented in base.Service
        private readonly ICategoryRepository _categoryRepository;

        // Constructor that passes the repository with Category to the base constructor and Instantiate the ICategoryRepository
        public CategoryService(IRepository<Category> repository, ICategoryRepository categoryRepository) : base(repository)
        {   
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        // Method to get a category with its exercises
        public async Task<IEnumerable<CategoryDto>> GetCategoryWithExercises(int categoriesId)
        {
            var entities = await _categoryRepository.GetCategoryWithExercisesAsync(categoriesId);
            if (entities is null)
                throw new ApplicationException("Category with exercises could not be found.");

            var mappedEntities = ObjectMapper.Mapper.Map<IEnumerable<CategoryDto>>(entities);
            if (mappedEntities is null)
                throw new ApplicationException("Category with exercises could not be mapped.");

            return mappedEntities;
        }
    }
}

