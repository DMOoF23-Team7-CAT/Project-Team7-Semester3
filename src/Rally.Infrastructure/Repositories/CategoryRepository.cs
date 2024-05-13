using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Core.Entities;
using Rally.Core.Repositories;
using Rally.Core.Specifications;
using Rally.Infrastructure.Data;
using Rally.Infrastructure.Exceptions;
using Rally.Infrastructure.Repositories.Base;

namespace Rally.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(RallyContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetCategoryWithSignBasesAsync(int categoryId)
        {
            var spec = new CategoryWithSignBaseSpecification(categoryId);

            var category = (await GetAsync(spec)).FirstOrDefault();
            if (category is null)
                throw new InfrastructureException("Category not found");

            return category;
        }
    }
}

