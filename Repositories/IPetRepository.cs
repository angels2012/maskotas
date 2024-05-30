using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;
using Microsoft.AspNetCore.Mvc;

namespace maskotas.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet?>> GetAllAsync();
        Task<Pet?> GetByIdAsync(int petId);
        Task<Pet> AddAsync(Pet pet);
        Task<bool> DeleteAsync(int id);
        Task<Pet?> UpdateAsync(PetPutDto petDto, int id);
        Task<Pet?> PatchAsync(PetPatchDto petDto, int id);
    }
}