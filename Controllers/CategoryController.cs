using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.Data;
using maskotas.DataTransferObjects;
using maskotas.Extensions;
using maskotas.Models;
using maskotas.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace maskotas.Controllers
{
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("/api/categories")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
                return NotFound();

            var categoriesDto = categories.Select(x => x.ToDto());
            return Ok(categoriesDto);
        }

        [HttpGet]
        [Route("/api/categories/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
                return NotFound("doge");

            var categoryDto = category.ToDto();
            return Ok(categoryDto);
        }

        [HttpPost]
        [Route("/api/categories")]
        public async Task<IActionResult> Add([FromBody] CategoryPostDto categoryFromRequest)
        {
            Category category = categoryFromRequest.ToModel();
            var addedCategory = await _categoryRepository.AddAsync(category);

            if (addedCategory is not null)
            {
                var action = nameof(GetById);
                var fromRoute = new { id = addedCategory.CategoryId };
                var createdResource = addedCategory.ToDto();
                return CreatedAtAction(action, fromRoute, createdResource);
            }

            return StatusCode(500);
        }

        [HttpDelete]
        [Route("/api/categories/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool wasDeleteSuccessful = await _categoryRepository.DeleteAsync(id);

            if (wasDeleteSuccessful)
                return NoContent();

            return NotFound();

        }

        [HttpPut]
        [Route("/api/categories/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryPutDto categoryDto)
        {
            Category updatedCategory = await _categoryRepository.UpdateAsync(categoryDto, id);
            if (updatedCategory is null)
                return NotFound();

            return Ok(updatedCategory.ToDto());
        }


    }
}