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
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetCategories()
        {
            var categories =  await _context.Categories.ToListAsync();
            var mappedCategories = _mapper.Map<List<GetCategoryDto>>(categories);

            return mappedCategories;
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDetailsDto>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var mappedCategory = _mapper.Map<GetCategoryDetailsDto>(category);
            return mappedCategory;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, UpdateCategoryDto categoryDto)
        {
            var category = await _context.Categories.FindAsync(id);
            
            if (category == null)
            {
                return BadRequest();
            }

            _mapper.Map(categoryDto, category);
            var result = _context.Categories.Update(category);

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
        public async Task<ActionResult<CreateCategoryDto>> PostCategory(CreateCategoryDto categoryDto)
        {
            if(categoryDto == null)
            {
                return BadRequest();
            }

            var category = _mapper.Map<Category>(categoryDto);
            _context.Categories.Add(category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
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
    }
}
