using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.Equipment;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("GetAllEquipment")]
        public async Task<IActionResult> GetAllEquipment()
        {
            var equipment = await _equipmentService.GetAll();
            return Ok(equipment);
        }

        [HttpGet("GetEquipmentWithEquipmentBase")]
        public async Task<ActionResult> GetEquipmentWithEquipmentBase(int equipmentId)
        {
            var equipment = await _equipmentService.GetEquipmentWithEquipmentBase(equipmentId);
            return Ok(equipment);
        }

        [HttpGet("GetEquipmentById")]
        public async Task<IActionResult> GetEquipmentById(int equipmentId)
        {
            var equipment = await _equipmentService.GetById(equipmentId);
            return Ok(equipment);
        }

        [HttpPost("CreateEquipment")]
        public async Task<IActionResult> CreateEquipment(EquipmentWithoutIdDto equipmentDto)
        {
            var equipment = await _equipmentService.Create(equipmentDto);
            return Ok(equipment);
        }

        [HttpPut("UpdateEquipment")]
        public async Task<IActionResult> UpdateEquipment(EquipmentDto equipmentDto)
        {
            await _equipmentService.Update(equipmentDto);
            return Ok();
        }

        [HttpDelete("DeleteEquipment")]
        public async Task<IActionResult> DeleteEquipment(int equipmentId)
        {
            await _equipmentService.Delete(equipmentId);
            return Ok();
        }
    }
}

