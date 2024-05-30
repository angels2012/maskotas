using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Extensions
{
    public static class BreedToDto
    {
        public static BreedDto ToDto(this Breed breed)
        {
            return new BreedDto
            {
                BreedId = breed.BreedId,
                BreedName = breed.BreedName
            };
        }
    }
}