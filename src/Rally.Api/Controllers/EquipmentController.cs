using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.Equipment;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/equipment")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEquipment()
        {
            try
            {
                var equipment = await _equipmentService.GetAll();
                return Ok(equipment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipmentById(int id)
        {
            try
            {
                var equipment = await _equipmentService.GetById(id);
                if (equipment == null)
                    return NotFound();

                return Ok(equipment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetEquipmentWithEquipmentBase(int id)
        {
            try
            {
                var equipment = await _equipmentService.GetEquipmentWithEquipmentBase(id);
                if (equipment == null)
                    return NotFound();

                return Ok(equipment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment([FromBody] EquipmentWithoutIdDto equipmentDto)
        {
            try
            {
                var equipment = await _equipmentService.Create(equipmentDto);
                return CreatedAtAction(nameof(GetEquipmentById), new { equipmentId = equipment.Id }, equipment);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(int id, [FromBody] EquipmentWithoutIdDto equipmentDto)
        {
            try
            {
                await _equipmentService.Update(equipmentDto, id);
                return NoContent();
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            try
            {
                await _equipmentService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}


