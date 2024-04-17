using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Application.Dto;
using Rally.Application.Interfaces;
using Rally.Application.Services.Base;
using Rally.Core.Entities;
using Rally.Core.Repositories;

namespace Rally.Application.Services
{
    public class CategoryService : Service<CategoryDto, Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
        
        // NOTE: Methods are implemented in the base class with validation and potential logging.
    }
}

