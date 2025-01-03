﻿using BloggingPlatformAPI.DTOs;
using BlogginPlatformApi.Core.Application.Interfaces.Services;
using BlogginPlatformAPI.Core.Application.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class blogsController : ControllerBase
    {
        private readonly IValidator<BlogUpdateDTO> _updateValidator;
        private readonly IValidator<BlogInsertDTO> _insertValidator;
        private readonly IBlogCRUDService _blogService;

        public blogsController(IValidator<BlogUpdateDTO> updateValidator, IValidator<BlogInsertDTO> insertValidator, IBlogCRUDService blogService)
        {
            _updateValidator = updateValidator;
            _insertValidator = insertValidator;
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IEnumerable<BlogDTO>> GetAll() => await _blogService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var found = await _blogService.GetByIdAsync(id);
            return found == null ? NotFound() : Ok(found);
        }

        [HttpPost]
        public async Task<ActionResult<BlogDTO>> Create([FromBody] BlogInsertDTO Insert)
        {
            var validation = _insertValidator.Validate(Insert);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var blogCreated = await _blogService.InsertAsync(Insert);
            return CreatedAtAction(nameof(GetById), new { id = blogCreated.BlogId }, blogCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BlogDTO>> Update([FromRoute] int id, [FromBody] BlogUpdateDTO update)
        {
            var found = await _blogService.GetByIdAsync(id);
            if (found == null)
            {
                return NotFound();
            }
            var validate = _updateValidator.Validate(update);
            if (!validate.IsValid)
            {
                return BadRequest(validate.Errors);
            }
            var infoUpdated = await _blogService.UpdateAsync(id, update);
            return infoUpdated == null ? BadRequest() : Ok(infoUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var infoDeleted = await _blogService.DeleteAsync(id);
            return infoDeleted == null ? NotFound() : Ok(infoDeleted);
        }

        [HttpGet("categories")]
        public ActionResult<IEnumerable<BlogDTO>> GetByCategory([FromQuery]string category)
        {
            var found = _blogService.FilterByCategoryAsync(category);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }
    }
}

