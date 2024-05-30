using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Extensions;
using maskotas.Models;
using maskotas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maskotas.Controllers
{
    [ApiController]
    [Authorize]
    public class BreedController : ControllerBase
    {
        private readonly IBreedRepository _breedRepository;
        public BreedController(IBreedRepository breedRepository)
        {
            _breedRepository = breedRepository;
        }

        [HttpGet]
        [Route("/api/breeds")]
        public async Task<IActionResult> GetAll()
        {
            var breeds = await _breedRepository.GetAllAsync();
            if (breeds == null)
                return NotFound();

            var breedsDto = breeds.Select(x => x.ToDto());
            return Ok(breedsDto);
        }

        [HttpGet]
        [Route("/api/breeds/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var breeds = await _breedRepository.GetAsync(id);
            if (breeds == null)
                return NotFound();

            var breedDto = breeds.ToDto();
            return Ok(breedDto);
        }

        [HttpPost]
        [Route("/api/breeds")]
        public async Task<IActionResult> Add([FromBody] BreedPostDto breedFromRequest)
        {
            Breed breed = breedFromRequest.ToModel();
            var addedBreed = await _breedRepository.AddAsync(breed);

            if (addedBreed is not null)
            {
                var action = nameof(GetById);
                var fromRoute = new { id = addedBreed.BreedId };
                var createdResource = addedBreed.ToDto();
                return CreatedAtAction(action, fromRoute, createdResource);
            }

            return StatusCode(500);
        }

        [HttpDelete]
        [Route("/api/breeds/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool wasDeleteSuccessful = await _breedRepository.DeleteAsync(id);

            if (wasDeleteSuccessful)
                return NoContent();

            return NotFound();
        }

        [HttpPut]
        [Route("/api/breeds/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BreedPutDto breedDto)
        {
            Breed updatedBreed = await _breedRepository.UpdateAsync(breedDto, id);
            if (updatedBreed is null)
                return NotFound();

            return Ok(updatedBreed.ToDto());
        }
    }
}