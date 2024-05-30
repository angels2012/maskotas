using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public List<Pet> Pets { get; set; } = [];
    }

    // public class PetLocation
    // {
    //     public int PetId { get; set; }
    //     public Pet Pet { get; set; }

    //     public int LocationId { get; set; }
    //     public Location Location { get; set; }
    // }
}