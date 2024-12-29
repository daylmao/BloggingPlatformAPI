using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {
        private readonly ICRUDService<CategoryDTO, CategoryInsertDTO, CategoryUpdateDTO> _categoryService;
        private readonly IValidator<CategoryInsertDTO> _insertValidator;
        private readonly IValidator<CategoryUpdateDTO> _updateValidator;

        public categoriesController(ICRUDService<CategoryDTO, CategoryInsertDTO, CategoryUpdateDTO> categoryService, IValidator<CategoryInsertDTO> insertValidator, IValidator<CategoryUpdateDTO> updateValidator)
        {
            _categoryService = categoryService;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetAll() => await _categoryService.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById([FromRoute] int id)
        {
            var found = await _categoryService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryInsertDTO insert)
        {
            var validated = _insertValidator.Validate(insert);
            if (!validated.IsValid)
            {
                return BadRequest(validated.Errors);
            }

            var categoryCreated = await _categoryService.Insert(insert);
            return CreatedAtAction(nameof(GetById), new { id = categoryCreated.CategoryId }, categoryCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdateDTO update)
        {
            var found = await _categoryService.GetById(id);

            if (found == null)
            {
                return NotFound();
            }

            var validated = _updateValidator.Validate(update);
            if (!validated.IsValid)
            {
                return BadRequest(validated.Errors);
            }
            var infoUpdated = await _categoryService.Update(id, update);
            return infoUpdated == null ? NotFound() : Ok(infoUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory([FromRoute] int id)
        {
            var blogDeleted = await _categoryService.Delete(id);
            return blogDeleted == null ? NotFound() : Ok(blogDeleted);
        }
    }
}

