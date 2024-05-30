using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.Data;
using maskotas.DataTransferObjects;
using maskotas.Models;
using Microsoft.EntityFrameworkCore;

namespace maskotas.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly MaskotasDbContext _dbContext;

        public BreedRepository(MaskotasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Breed?> AddAsync(Breed breed)
        {
            await _dbContext.Breeds.AddAsync(breed);
            await _dbContext.SaveChangesAsync();
            return await GetAsync(breed.BreedId);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var breed = await _dbContext.Breeds.FirstOrDefaultAsync(x => x.BreedId == id);
            if (breed == null)
                return false;

            _dbContext.Breeds.Remove(breed);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Breed>?> GetAllAsync()
        {
            var breeds = await _dbContext.Breeds.ToListAsync();
            return breeds;
        }

        public async Task<Breed?> GetAsync(int id)
        {
            var breed = await _dbContext.Breeds.FirstOrDefaultAsync(x => x.BreedId == id);
            return breed;
        }

        public async Task<Breed?> UpdateAsync(BreedPutDto breedDto, int id)
        {
            var inDbBreed = await _dbContext.Breeds.FirstOrDefaultAsync(x => x.BreedId == id);
            if (inDbBreed is null)
                return null;

            inDbBreed.BreedName = breedDto.BreedName;
            await _dbContext.SaveChangesAsync();
            return inDbBreed;
        }
    }
}