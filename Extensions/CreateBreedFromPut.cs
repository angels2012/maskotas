using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;

namespace maskotas.Extensions
{
    public static class CreateBreedFromPut
    {
        public static Breed ToModel(this BreedPutDto breedDto)
        {
            return new Breed
            {
                BreedName = breedDto.BreedName
            };
        }
    }
}