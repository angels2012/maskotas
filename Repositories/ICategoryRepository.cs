using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>?> GetAllAsync();
        Task<Category?> GetAsync(int id);
        Task<Category?> AddAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<Category?> UpdateAsync(CategoryPutDto categoryDto, int id);
    }
}