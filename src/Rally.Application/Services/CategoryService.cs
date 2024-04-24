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

        // Method to get a category with its SignBases
        public async Task<CategoryDto> GetCategoryWithSignBases(int categoryId)
        {
            var entity = await _categoryRepository.GetCategoryWithSignBasesAsync(categoryId);
            //NOTE - No need to check if entity is null here, because there is null checks in the Infrastructure layer.

            var mappedEntity = ObjectMapper.Mapper.Map<CategoryDto>(entity);
            if (mappedEntity is null)
                throw new ApplicationException("Category with SignBases could not be mapped.");

            return mappedEntity;
        }
    }
}

