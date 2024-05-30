using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Extensions
{
    public static class CreatePetFromPost
    {
        public static Pet ToModel(this PetPostDto petDto)
        {
            return new Pet
            {
                Name = petDto.Name,
                Description = petDto.Description,
                Age = petDto.Age,
                ImageUrl = petDto.ImageUrl,
                BreedId = petDto.BreedId,
                LocationId = petDto.LocationId,
                CategoryId = petDto.CategoryId,
            };
        }
    }
}