using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rally.Api.Data;
using Rally.Api.Dtos.Exercise;
using Rally.Api.Models;

namespace Rally.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly RallyDbContext _context;
        private readonly IMapper _mapper;

        public ExerciseController(RallyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Exercise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseDto>>> GetExercises()
        {
            var exercise = await _context.Exercises.ToListAsync();
            var mappedExercises = _mapper.Map<List<ExerciseDto>>(exercise);

            return mappedExercises;
        }

        // GET: api/Exercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseDetailsDto>> GetExercise(int id)
        {
            var exercise = await _context.Exercises.Include(e => e.Equipment)
                .Include(e => e.Categories).FirstOrDefaultAsync(e => e.Id == id);

            if (exercise == null)
            {
                return NotFound();
            }

            var mappedExercise = _mapper.Map<ExerciseDetailsDto>(exercise);

            return mappedExercise;
        }

        // PUT: api/Exercise/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, UpdateExerciseDto updateExerciseDto)
        {
            if (updateExerciseDto == null || id <= 0)
            {
                return BadRequest("Invalid data or ID.");
            }

            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            var mappedExercise = _mapper.Map(updateExerciseDto, exercise);
            _context.Update(mappedExercise);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercise
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise(CreateExerciseDto createExerciseDto)
        {
            if (createExerciseDto == null)
            {
                return BadRequest("Invalid data");
            }

            var mappedExercise = _mapper.Map<Exercise>(createExerciseDto);
            _context.Add(mappedExercise);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExerciseExists(mappedExercise.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExercise", new { id = mappedExercise.Id }, mappedExercise);
        }

        // DELETE: api/Exercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.Id == id);
        }
    }
}
