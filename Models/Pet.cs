using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string ImageUrl { get; set; }

        public Category Category { get; set; }
        public Location Location { get; set; }
        public Breed Breed { get; set; }

        public int CategoryId { get; set; }
        public int BreedId { get; set; }
        public int LocationId { get; set; }
    }
}