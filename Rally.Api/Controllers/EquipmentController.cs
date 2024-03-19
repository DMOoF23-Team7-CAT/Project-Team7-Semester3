using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rally.Api.Data;
using Rally.Api.Dtos.Equipment;
using Rally.Api.Models;

namespace Rally.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly RallyDbContext _context;
        private readonly IMapper _mapper;

        public EquipmentController(RallyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Equipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDto>>> GetEquipments()
        {
            var equipment = await _context.Equipments.ToListAsync();
            var mappedEquipment = _mapper.Map<List<EquipmentDto>>(equipment);

            return mappedEquipment;
        }

        // GET: api/Equipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDetailsDto>> GetEquipment(int id)
        {
            var equipment = await _context.Equipments.Include(e => e.Exercises)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipment == null)
            {
                return NotFound();
            }

            var mappedEquipment = _mapper.Map<EquipmentDetailsDto>(equipment);

            return mappedEquipment;
        }

        // PUT: api/Equipment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(int id, UpdateEquipmentDto updateEquipmentDto)
        {
            if (updateEquipmentDto == null || id <= 0)
            {
                return BadRequest("Invalid data or ID.");
            }

            var Equipment = await _context.Equipments.FindAsync(id);
            if (Equipment == null)
            {
                return NotFound();
            }

            // Apply updates from updateCategoryDto to the retrieved category
            _mapper.Map(updateEquipmentDto, Equipment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
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

        // POST: api/Equipment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(CreateEquipmentDto createEquipmentDto)
        {
            if (createEquipmentDto == null)
            {
                return BadRequest("Invalid data");
            }

            var mappedEquipment = _mapper.Map<Equipment>(createEquipmentDto);
            _context.Equipments.Add(mappedEquipment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EquipmentExists(mappedEquipment.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEquipment", new { id = mappedEquipment.Id }, mappedEquipment);
        }

        // DELETE: api/Equipment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipments.Any(e => e.Id == id);
        }
    }
}
