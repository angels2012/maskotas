using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Repositories
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location?> GetAsync(int id);
        Task<Location?> AddAsync(Location location);
        Task<bool> DeleteAsync(int id);
        Task<Location?> UpdateAsync(LocationPutDto location, int id);
    }
}