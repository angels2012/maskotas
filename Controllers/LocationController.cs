using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Extensions;
using maskotas.Models;
using maskotas.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace maskotas.Controllers
{
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        [Route("/api/location/getall")]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _locationRepository.GetAllAsync();
            if (locations == null)
                return NotFound();

            var locationsDto = locations.Select(x => x.ToDto());
            return Ok(locationsDto);
        }

        [HttpGet]
        [Route("/api/location/getbyid/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var location = await _locationRepository.GetAsync(id);
            if (location == null)
                return NotFound();

            var locationDto = location.ToDto();
            return Ok(locationDto);
        }

        [HttpPost]
        [Route("/api/location/add")]
        public async Task<IActionResult> Add([FromBody] LocationPostDto locationDto)
        {
            Location location = locationDto.ToModel();
            var addedlocation = await _locationRepository.AddAsync(location);

            if (addedlocation is not null)
            {
                var action = nameof(GetById);
                var fromRoute = new { id = addedlocation.LocationId };
                var createdResource = addedlocation.ToDto();
                return CreatedAtAction(action, fromRoute, createdResource);
            }

            return StatusCode(500);
        }

        [HttpDelete]
        [Route("/api/location/delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await _locationRepository.DeleteAsync(id);
            if (result)
                return NoContent();

            return NotFound();
        }

        [HttpPut]
        [Route("/api/location/update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] LocationPutDto locationDto)
        {
            Location updatedLocation = await _locationRepository.UpdateAsync(locationDto, id);
            if (updatedLocation is null)
                return NotFound();

            return Ok(updatedLocation.ToDto());
        }

    }
}