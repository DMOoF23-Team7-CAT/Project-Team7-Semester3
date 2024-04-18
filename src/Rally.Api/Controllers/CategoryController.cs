using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        //FIXME - This is only an example. the proper way needs mapping and validation
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }

        //FIXME - This is only an example. the proper way needs mapping and validation
        [HttpGet]
        public async Task<IActionResult> GetCategoriesWithExercises(int categoryId)
        {
            var categories = await _categoryService.GetCategoryWithExercises(categoryId);
            return Ok(categories);
        }
    }
}

