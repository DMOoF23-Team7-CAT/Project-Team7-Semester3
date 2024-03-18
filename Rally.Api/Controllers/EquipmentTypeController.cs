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
    public class EquipmentTypeController : ControllerBase
    {
        private readonly RallyDbContext _context;

        public EquipmentTypeController(RallyDbContext context)
        {
            _context = context;
        }

        // GET: api/EquipmentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentType>>> GetEquipmentTypes()
        {
            return await _context.EquipmentTypes.ToListAsync();
        }

        // GET: api/EquipmentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentType>> GetEquipmentType(int id)
        {
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);

            if (equipmentType == null)
            {
                return NotFound();
            }

            return equipmentType;
        }

        // PUT: api/EquipmentType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentType(int id, EquipmentType equipmentType)
        {
            if (id != equipmentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentTypeExists(id))
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

        // POST: api/EquipmentType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EquipmentType>> PostEquipmentType(EquipmentType equipmentType)
        {
            _context.EquipmentTypes.Add(equipmentType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentTypeExists(equipmentType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipmentType", new { id = equipmentType.Id }, equipmentType);
        }

        // DELETE: api/EquipmentType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentType(int id)
        {
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);
            if (equipmentType == null)
            {
                return NotFound();
            }

            _context.EquipmentTypes.Remove(equipmentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentTypeExists(int id)
        {
            return _context.EquipmentTypes.Any(e => e.Id == id);
        }
    }
}
