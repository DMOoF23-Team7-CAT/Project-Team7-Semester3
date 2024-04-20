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
    public class SignController : ControllerBase
    {
        private readonly RallyDbContext _context;

        public SignController(RallyDbContext context)
        {
            _context = context;
        }

        // GET: api/Sign
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sign>>> GetSign()
        {
            return await _context.Sign.ToListAsync();
        }

        // GET: api/Sign/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sign>> GetSign(int id)
        {
            var sign = await _context.Sign.FindAsync(id);

            if (sign == null)
            {
                return NotFound();
            }

            return sign;
        }

        // PUT: api/Sign/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSign(int id, Sign sign)
        {
            if (id != sign.Id)
            {
                return BadRequest();
            }

            _context.Entry(sign).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignExists(id))
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

        // POST: api/Sign
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sign>> PostSign(Sign sign)
        {
            _context.Sign.Add(sign);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSign", new { id = sign.Id }, sign);
        }

        // DELETE: api/Sign/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSign(int id)
        {
            var sign = await _context.Sign.FindAsync(id);
            if (sign == null)
            {
                return NotFound();
            }

            _context.Sign.Remove(sign);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SignExists(int id)
        {
            return _context.Sign.Any(e => e.Id == id);
        }
    }
}
