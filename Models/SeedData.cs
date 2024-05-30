using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.Data;
using Microsoft.EntityFrameworkCore;

namespace maskotas.Models
{
    public class SeedData
    {
        private static void SeedPets(MaskotasDbContext context)
        {
            if (context.Pets.Any())
            {
                return;   // DB has been seeded
            }
            context.Pets.AddRange(
                new Pet
                {
                    PetId = 0,
                    Name = "Poo",
                    Description = "Cute small dog",
                    Age = 4,
                    ImageUrl = "http://localhost:5291/pet1.jpg",
                    LocationId = 1,
                    BreedId = 0,
                    CategoryId = 2,
                },
                new Pet
                {
                    PetId = 1,
                    Name = "Poo",
                    Description = "Cute small dog",
                    Age = 4,
                    ImageUrl = "http://localhost:5291/pet2.jpg",
                    LocationId = 1,
                    BreedId = 0,
                    CategoryId = 2,
                },
                new Pet
                {
                    PetId = 2,
                    Name = "Poo",
                    Description = "Cute small dog",
                    Age = 4,
                    ImageUrl = "http://localhost:5291/pet3.jpg",
                    LocationId = 1,
                    BreedId = 0,
                    CategoryId = 2,
                }
            );
            return;

        }

        private static void SeedLocations(MaskotasDbContext context)
        {
            if (context.Locations.Any())
            {
                return;   // DB has been seeded
            }
            return;
        }

        private static void SeedBreeds(MaskotasDbContext context)
        {
            if (context.Breeds.Any())
            {
                return;   // DB has been seeded
            }

            context.Breeds.AddRange(
                new Breed
                {
                    BreedId = 0,
                    BreedName = "Golden Retriever"
                },
                new Breed
                {
                    BreedId = 1,
                    BreedName = "Shih Tzu"
                },
                new Breed
                {
                    BreedId = 2,
                    BreedName = "Bulldog"
                }
            );
            return;

        }

        private static void SeedCategories(MaskotasDbContext context)
        {
            if (context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            return;
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MaskotasDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MaskotasDbContext>>()))
            {
                if (context == null || context.Pets == null)
                {
                    throw new ArgumentNullException("Null context");
                }

                // SeedPets(context);
                SeedBreeds(context);
                // SeedLocations(context);
                // SeedCategories(context);

                context.SaveChanges();
            }
        }
    }
}