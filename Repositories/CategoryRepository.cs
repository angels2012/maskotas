using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.Data;
using maskotas.DataTransferObjects;
using maskotas.Extensions;
using maskotas.Models;
using Microsoft.EntityFrameworkCore;

namespace maskotas.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly MaskotasDbContext _dbContext;
        public CategoryRepository(MaskotasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category?> AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == category.CategoryId);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (category == null)
                return false;

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>?> GetAllAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category?> GetAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(X => X.CategoryId == id);
            return category;
        }

        public async Task<Category?> UpdateAsync(CategoryPutDto categoryDto, int id)
        {
            var inDbCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (inDbCategory is null)
                return null;

            inDbCategory.CategoryName = categoryDto.CategoryName;
            await _dbContext.SaveChangesAsync();
            return inDbCategory;
        }
    }
}