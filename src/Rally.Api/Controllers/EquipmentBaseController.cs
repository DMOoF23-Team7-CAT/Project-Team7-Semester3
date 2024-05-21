using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.EquipmentBase;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentBaseController : ControllerBase
    {
        private readonly IEquipmentBaseService _equipmentBaseService;

        public EquipmentBaseController(IEquipmentBaseService equipmentBaseService)
        {
            _equipmentBaseService = equipmentBaseService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetEquipmentBases()
        {
            try
            {
                var equipmentBases = await _equipmentBaseService.GetAll();
                return Ok(equipmentBases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEquipmentBaseById(int Id)
        {
            try
            {
                var equipmentBase = await _equipmentBaseService.GetById(Id);
                if (equipmentBase == null)
                    return NotFound();

                return Ok(equipmentBase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEquipmentBase([FromBody] EquipmentBaseDto equipmentBaseDto)
        {
            try
            {
                var equipmentBase = await _equipmentBaseService.Create(equipmentBaseDto);
                return CreatedAtAction(nameof(GetEquipmentBaseById), new { equipmentBaseId = equipmentBase.Id }, equipmentBase);
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

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateEquipmentBase(int Id, [FromBody] EquipmentBaseDto equipmentBaseDto)
        {
            try
            {
                await _equipmentBaseService.Update(equipmentBaseDto, Id);
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEquipmentBase(int Id)
        {
            try
            {
                await _equipmentBaseService.Delete(Id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

