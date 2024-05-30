using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.Data;
using maskotas.DataTransferObjects;
using maskotas.Extensions;
using maskotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maskotas.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly MaskotasDbContext _dbContext;

        public PetRepository(MaskotasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pet> AddAsync(Pet pet)
        {
            await _dbContext.Pets.AddAsync(pet);
            await _dbContext.SaveChangesAsync();
            Pet addedPet = await GetByIdAsync(pet.PetId);
            return addedPet;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pet = await _dbContext.Pets.FirstOrDefaultAsync(x => x.PetId == id);
            if (pet == null)
                return false;

            _dbContext.Pets.Remove(pet);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            List<Pet> pets = await _dbContext.Pets.Include(pet => pet.Breed)
                                    .Include(pet => pet.Category)
                                    .Include(pet => pet.Location)
                                    .ToListAsync();

            return pets;
        }

        public async Task<Pet?> GetByIdAsync(int petId)
        {
            var pets = await _dbContext.Pets.Include(pet => pet.Breed)
                                    .Include(pet => pet.Category)
                                    .Include(pet => pet.Location)
                                    .ToListAsync();
            var foundPet = pets.FirstOrDefault(pet => pet.PetId == petId);
            return foundPet;
        }

        public async Task<Pet?> PatchAsync(PetPatchDto petDto, int id)
        {
            var foundPet = await _dbContext.Pets.FirstOrDefaultAsync(x => x.PetId == id);
            if (foundPet == null)
                return null;
            foundPet.Name = petDto.Name ?? foundPet.Name;
            foundPet.Description = petDto.Description ?? foundPet.Description;
            foundPet.Age = petDto.Age ?? foundPet.Age;
            foundPet.ImageUrl = petDto.ImageUrl ?? foundPet.ImageUrl;
            foundPet.CategoryId = petDto.CategoryId ?? foundPet.CategoryId;
            foundPet.LocationId = petDto.LocationId ?? foundPet.LocationId;
            foundPet.BreedId = petDto.BreedId ?? foundPet.BreedId;
            await _dbContext.SaveChangesAsync();
            var finalPet = await _dbContext.Pets
                    .Include(pet => pet.Breed)
                    .Include(pet => pet.Location)
                    .Include(pet => pet.Category)
                    .Where(pet => pet.PetId == id)
                    .FirstOrDefaultAsync();
            return finalPet;
        }

        public async Task<Pet?> UpdateAsync(PetPutDto petDto, int id)
        {
            var inDbPet = await _dbContext.Pets.FirstOrDefaultAsync(x => x.PetId == id);

            if (inDbPet == null)
                return null;

            inDbPet.Name = petDto.Name;
            inDbPet.Description = petDto.Description;
            inDbPet.Age = petDto.Age;
            inDbPet.ImageUrl = petDto.ImageUrl;
            inDbPet.BreedId = petDto.BreedId;
            inDbPet.LocationId = petDto.LocationId;
            inDbPet.CategoryId = petDto.CategoryId;

            await _dbContext.SaveChangesAsync();
            var finalPet = await _dbContext.Pets
                                .Include(pet => pet.Breed)
                                .Include(pet => pet.Location)
                                .Include(pet => pet.Category)
                                .Where(pet => pet.PetId == id)
                                .FirstOrDefaultAsync();
            return finalPet;
        }
    }
}