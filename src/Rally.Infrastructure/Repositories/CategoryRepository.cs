using Microsoft.EntityFrameworkCore;
using Rally.Core.Entities;
using Rally.Core.Repositories;

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

            var category = await _dbContext.Set<Category>()
                .Include(c => c.SignBases)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category is null)
                throw new InfrastructureException("Category not found");

            return category;
        }
    }
}

