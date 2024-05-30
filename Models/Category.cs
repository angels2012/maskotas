using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Pet> Pets { get; set; } = [];
    }

    // public class PetCategory
    // {
    //     public int PetId { get; set; }
    //     public Pet Pet { get; set; }

    //     public int CategoryId { get; set; }
    //     public Category Category { get; set; }
    // }
}