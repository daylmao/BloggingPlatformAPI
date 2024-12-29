using BloggingPlatformAPI.DTOs;
using BloggingPlatformAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class blogsController : ControllerBase
    {
        private readonly IValidator<BlogUpdateDTO> _updateValidator;
        private readonly IValidator<BlogInsertDTO> _insertValidator;
        private readonly ICRUDService<BlogDTO, BlogInsertDTO, BlogUpdateDTO> _blogService;

        public blogsController(IValidator<BlogUpdateDTO> updateValidator, IValidator<BlogInsertDTO> insertValidator, ICRUDService<BlogDTO, BlogInsertDTO, BlogUpdateDTO> blogService)
        {
            _updateValidator = updateValidator;
            _insertValidator = insertValidator;
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IEnumerable<BlogDTO>> GetAll() => await _blogService.GetAll();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var found = await _blogService.GetById(id);
            return found == null ? NotFound() : Ok(found);
        }

        [HttpPost()]
        public async Task<ActionResult<BlogDTO>> CreateBlogs([FromBody] BlogInsertDTO Insert)
        {
            var validation = _insertValidator.Validate(Insert);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var blogCreated = await _blogService.Insert(Insert);
            return CreatedAtAction(nameof(GetById), new { id = blogCreated.BlogId }, blogCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BlogDTO>> UpdateBlog([FromRoute] int id, [FromBody] BlogUpdateDTO update)
        {
            var found = await _blogService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            var validate = _updateValidator.Validate(update);
            if (!validate.IsValid)
            {
                return BadRequest(validate.Errors);
            }
            var infoUpdated = await _blogService.Update(id, update);
            return infoUpdated == null ? BadRequest() : Ok(infoUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlog([FromRoute] int id)
        {
            var infoDeleted = await _blogService.Delete(id);
            return infoDeleted == null ? NotFound() : Ok(infoDeleted);
        }

        [HttpGet("category")]
        public ActionResult<IEnumerable<BlogDTO>> FilterByCategory([FromQuery]string category)
        {
            var found = _blogService.FilterByCategory(category);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }
    }
}

