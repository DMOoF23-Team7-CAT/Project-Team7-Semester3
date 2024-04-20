using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rally.Api.Data;
using Rally.Api.Dtos.Category;
using Rally.Api.Models;

namespace Rally.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly RallyDbContext _context;
        private readonly IMapper _mapper;

        public CategoryController(RallyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var mappedCategories = _mapper.Map<List<CategoryDto>>(categories);

            return mappedCategories;
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailsDto>> GetCategory(int id)
        {
            var category = await _context.Categories.Include(c => c.Exercises)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var mappedCategory = _mapper.Map<CategoryDetailsDto>(category);

            return mappedCategory;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            if (updateCategoryDto == null || id <= 0)
            {
                return BadRequest("Invalid data or ID.");
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Apply updates from updateCategoryDto to the retrieved category
            _mapper.Map(updateCategoryDto, category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateCategoryDto>> PostCategory(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null)
            {
                return BadRequest("Invalid data");
            }

            var mappedCategory = _mapper.Map<Category>(createCategoryDto);
            _context.Add(mappedCategory);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(mappedCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategory", new { id = mappedCategory.Id }, mappedCategory);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        [HttpPost("api/categories/{categoryId}/exercises")]
        public async Task<ActionResult<CategoryDetailsDto>> AddExerciseToCategory(int categoryId, int exerciseId)
        {
            // Retrieve the Category and Exercise by their IDs
            var category = await _context.Categories
                .Include(c => c.Exercises)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            var exercise = await _context.Exercises.FindAsync(exerciseId);

            // Check if either the category or exercise is null
            if (category == null || exercise == null)
                return BadRequest("Invalid Category or Exercise");

            // Ensure the category's Exercises collection is not null
            category.Exercises ??= new List<Exercise>();

            // Check if the exercise already exists in the category's collection
            if (category.Exercises.Any(e => e.Id == exercise.Id))
                return Conflict("Exercise already exists in the category");

            // Add the exercise to the category
            category.Exercises.Add(exercise);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return Conflict(e.Message);
            }

            var mappedCategory = _mapper.Map<CategoryDetailsDto>(category);
            return Ok(mappedCategory);
        }


        // [HttpPost("api/categories/{categoryId}/tracks")]
        // public async Task<ActionResult<CategoryDetailsDto>> AddTrackToCategory(int categoryId, int trackId)
        // {
        //     var category = await _context.Categories.Include(c => c.Tracks)
        //         .FirstOrDefaultAsync(c => c.Id == categoryId);

        //     if (category == null) return BadRequest("Invalid Category");

        //     var track = await _context.Tracks.FindAsync(trackId);

        //     if (track == null) return BadRequest("Invalid Track");

        //     category.Tracks ??= new List<Track>();

        //     category.Tracks.Add(track);

        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetCategory", new { id = categoryId });
        // }



    }
}
