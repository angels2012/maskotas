using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Extensions
{
    public static class PetToDto
    {
        public static PetDto ToDto(this Pet pet)
        {
            var categoryDto = new CategoryDto
            {
                CategoryId = pet.Category.CategoryId,
                CategoryName = pet.Category.CategoryName
            };

            var breedDto = new BreedDto
            {
                BreedId = pet.Breed.BreedId,
                BreedName = pet.Breed.BreedName
            };

            var locationDto = new LocationDto
            {
                LocationId = pet.Location.LocationId,
                LocationName = pet.Location.LocationName
            };

            var petDto = new PetDto
            {
                PetId = pet.PetId,
                Name = pet.Name,
                Description = pet.Description,
                Age = pet.Age,
                ImageUrl = pet.ImageUrl,
                BreedDto = breedDto,
                LocationDto = locationDto,
                CategoryDto = categoryDto
            };
            return petDto;
        }
    }
}