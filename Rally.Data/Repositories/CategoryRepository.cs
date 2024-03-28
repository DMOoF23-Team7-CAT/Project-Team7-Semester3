using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rally.Domain.Interfaces;
using Rally.Domain.Entity;
using Rally.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Rally.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RallyDbContext _context;

        public CategoryRepository(RallyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await _context.Categories.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding the category.", ex);
            }
        }

        public async Task DeleteAsync(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting the category.", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving all categories.", ex);
            }
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    throw new Exception("Category not found.");
                }
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving the category by ID.", ex);
            }
        }

        public async Task UpdateAsync(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                _context.Categories.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating the category.", ex);
            }
        }
    }
}