using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.DataTransferObjects
{
    public class PetDto
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }

        public CategoryDto CategoryDto { get; set; }
        public LocationDto LocationDto { get; set; }
        public BreedDto BreedDto { get; set; }
    }
}