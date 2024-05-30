using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace maskotas.Data
{
    public class MaskotasDbContext : IdentityDbContext<AppUser>
    {
        public MaskotasDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = [
                new IdentityRole {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole {
                    Name = "User",
                    NormalizedName = "USER"
                }
            ];
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<Location>()
                .HasMany(location => location.Pets)
                .WithOne(pet => pet.Location);

            builder.Entity<Breed>()
                .HasMany(breed => breed.Pets)
                .WithOne(pet => pet.Breed);

            builder.Entity<Category>()
                .HasMany(category => category.Pets)
                .WithOne(pet => pet.Category);

            List<Breed> breeds = [
                new Breed
                {
                    BreedId = 1,
                    BreedName = "Golden Retriever"
                },
                new Breed
                {
                    BreedId = 2,
                    BreedName = "Shih Tzu"
                },
                new Breed
                {
                    BreedId = 3,
                    BreedName = "Bulldog"
                }
            ];
            List<Location> locations = [
                new Location {
                    LocationId = 1,
                    LocationName = "Zacatecas"
                },
                new Location {
                    LocationId = 2,
                    LocationName = "Aguascalientes"
                },
                new Location {
                    LocationId = 3,
                    LocationName = "Guadalajara"
                }
            ];
            List<Category> categories = [
                new Category {
                    CategoryId = 1,
                    CategoryName = "Dog"
                },
                new Category {
                    CategoryId = 2,
                    CategoryName = "Cat"
                },
                new Category {
                    CategoryId = 3,
                    CategoryName = "Turtle"
                },
            ];
            List<Pet> pets = [
 new Pet
                {
                    PetId = 1,
                    Name = "Panda",
                    Description = "Black and white dog, looks like a panda!",
                    Age = 2,
                    ImageUrl = "http://localhost:5291/pet1.jpg",
                    LocationId = 1,
                    BreedId = 1,
                    CategoryId = 1,
                },
                new Pet
                {
                    PetId = 2,
                    Name = "Poo",
                    Description = "Cute small dog",
                    Age = 4,
                    ImageUrl = "http://localhost:5291/pet2.jpg",
                    LocationId = 2,
                    BreedId = 1,
                    CategoryId = 1,
                },
                new Pet
                {
                    PetId = 3,
                    Name = "William",
                    Description = "Medium size dog, on the older side. He's so wise!",
                    Age = 6,
                    ImageUrl = "http://localhost:5291/pet3.jpg",
                    LocationId = 3,
                    BreedId = 1,
                    CategoryId = 1,
                }
            ];
            builder.Entity<Breed>().HasData(breeds);
            builder.Entity<Location>().HasData(locations);
            builder.Entity<Category>().HasData(categories);
            builder.Entity<Pet>().HasData(pets);

        }

    }
}