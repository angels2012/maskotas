using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Repositories
{
    public interface IBreedRepository
    {
        Task<IEnumerable<Breed>?> GetAllAsync();
        Task<Breed?> GetAsync(int id);
        Task<Breed?> AddAsync(Breed breed);
        Task<bool> DeleteAsync(int id);
        Task<Breed?> UpdateAsync(BreedPutDto breed, int id);
    }
}