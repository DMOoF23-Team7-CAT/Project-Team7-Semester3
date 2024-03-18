using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rally.Api.Data;
using Rally.Api.Models;

namespace Rally.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseTypeController : ControllerBase
    {
        private readonly RallyDbContext _context;

        public ExerciseTypeController(RallyDbContext context)
        {
            _context = context;
        }

        // GET: api/ExerciseType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseType>>> GetExerciseTypes()
        {
            return await _context.ExerciseTypes.ToListAsync();
        }

        // GET: api/ExerciseType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseType>> GetExerciseType(int id)
        {
            var exerciseType = await _context.ExerciseTypes.FindAsync(id);

            if (exerciseType == null)
            {
                return NotFound();
            }

            return exerciseType;
        }

        // PUT: api/ExerciseType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseType(int id, ExerciseType exerciseType)
        {
            if (id != exerciseType.Id)
            {
                return BadRequest();
            }

            _context.Entry(exerciseType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseTypeExists(id))
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

        // POST: api/ExerciseType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExerciseType>> PostExerciseType(ExerciseType exerciseType)
        {
            _context.ExerciseTypes.Add(exerciseType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExerciseTypeExists(exerciseType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExerciseType", new { id = exerciseType.Id }, exerciseType);
        }

        // DELETE: api/ExerciseType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseType(int id)
        {
            var exerciseType = await _context.ExerciseTypes.FindAsync(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            _context.ExerciseTypes.Remove(exerciseType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseTypeExists(int id)
        {
            return _context.ExerciseTypes.Any(e => e.Id == id);
        }
    }
}
