using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.Category;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var categories = await _categoryService.GetById(categoryId);
            return Ok(categories);
        }

        [HttpGet("GetCategoryWithSignBases")]
        public async Task<IActionResult> GetCategoriesWithSignBases(int categoryId)
        {
            var categories = await _categoryService.GetCategoryWithSignBases(categoryId);
            return Ok(categories);
        }

        [HttpPost("CreateCategory")]
        [Authorize]

        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
        {
            var category = await _categoryService.Create(categoryDto);
            return Ok(category);
        }

        [HttpPut("UpdateCategory")]
        [Authorize]

        public async Task<IActionResult> UpdateCategory(CategoryDto category)
        {
            await _categoryService.Update(category);
            return Ok();
        }

        [HttpDelete("DeleteCategory")]
        [Authorize]

        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _categoryService.Delete(categoryId);
            return Ok();
        }
    }
}

