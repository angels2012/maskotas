using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using maskotas.Data;
using maskotas.DataTransferObjects;
using maskotas.Extensions;
using maskotas.Models;
using maskotas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace maskotas.Controllers
{
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpGet]
        [Route("/api/pets")]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _petRepository.GetAllAsync();
            if (pets == null)
                return NotFound();

            var petsDto = pets.Select(pet => pet.ToDto());
            return Ok(petsDto);
        }

        [HttpGet]
        [Route("/api/pets/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var pet = await _petRepository.GetByIdAsync(id);
            if (pet == null)
                return NotFound();
            else
                return Ok(pet.ToDto());
        }

        [HttpPost]
        [Route("/api/pets")]
        public async Task<IActionResult> Add([FromBody] PetPostDto petFromRequest)
        {
            Pet pet = petFromRequest.ToModel();
            var createdPet = await _petRepository.AddAsync(pet);

            if (createdPet is not null)
            {
                var action = nameof(GetById);
                var fromRoute = new { id = pet.PetId };
                var createdResource = pet.ToDto();
                return CreatedAtAction(action, fromRoute, createdResource);
            }

            return StatusCode(500);
        }

        [HttpDelete]
        [Route("/api/pets/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool wasDeleteSuccessful = await _petRepository.DeleteAsync(id);

            if (wasDeleteSuccessful)
                return NoContent();

            return NotFound();
        }

        [HttpPut]
        [Route("/api/pets/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PetPutDto petDto)
        {
            var finalPet = await _petRepository.UpdateAsync(petDto, id);
            if (finalPet is null)
                return NotFound();

            return Ok(finalPet.ToDto());
        }

        [HttpPatch]
        [Route("/api/pets/{id:int}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] PetPatchDto petDto)
        {
            var finalPet = await _petRepository.PatchAsync(petDto, id);
            if (finalPet is null)
                return NotFound();

            return Ok(finalPet.ToDto());
        }
    }
}