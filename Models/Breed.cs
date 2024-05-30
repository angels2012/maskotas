using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.Models
{
    public class Breed
    {
        public int BreedId { get; set; }
        public string BreedName { get; set; }

        public List<Pet> Pets { get; set; } = [];
    }

    // public class PetBreed
    // {
    //     public int PetId { get; set; }
    //     public Pet Pet { get; set; }

    //     public int BreedId { get; set; }
    //     public Breed Breed { get; set; }
    // }
}