using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<GetEquipmentWithTypeDto>>> GetEquipments()
        {
            var equipments = await _context.Equipments.ToListAsync();
            var mappedEquipments = _mapper.Map<List<GetEquipmentWithTypeDto>>(equipments);

            return mappedEquipments;
        }

        // GET: api/Equipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEquipmentWithTypeDto>> GetEquipment(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            var mappedEquipment = _mapper.Map<GetEquipmentWithTypeDto>(equipment);
            return mappedEquipment;
        }

        // PUT: api/Equipment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(int id, UpdateEquipmentDto equipmentDto)
        {
            var equipment = await _context.Equipments.FindAsync(id);

            if (equipment == null)
            {
                return BadRequest();
            }

            _mapper.Map(equipmentDto, equipment);
            _context.Equipments.Update(equipment);

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
        public async Task<ActionResult<CreateEquipmentDto>> PostEquipment(CreateEquipmentDto equipmentDto)
        {
            if (equipmentDto == null)
            {
                return BadRequest();
            }

            var equipment = _mapper.Map<Equipment>(equipmentDto);
            _context.Equipments.Add(equipment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (EquipmentExists(equipment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetEquipment", new { id = equipment.Id }, equipment);
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
