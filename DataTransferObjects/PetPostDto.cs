using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.DataTransferObjects
{
    public class PetPostDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public int BreedId { get; set; }
    }
}