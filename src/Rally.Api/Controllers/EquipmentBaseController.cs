using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.EquipmentBase;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentBaseController : ControllerBase
    {
        private readonly IEquipmentBaseService _equipmentBaseService;

        public EquipmentBaseController(IEquipmentBaseService equipmentBaseService)
        {
            _equipmentBaseService = equipmentBaseService;
        }

        [HttpGet("GetAllEquipmentBases")]
        public async Task<IActionResult> GetEquipmentBases()
        {
            var equipmentBases = await _equipmentBaseService.GetAll();
            return Ok(equipmentBases);
        }

        [HttpGet("GetEquipmentBaseById")]
        public async Task<IActionResult> GetEquipmentBaseById(int equipmentBaseId)
        {
            var equipmentBase = await _equipmentBaseService.GetById(equipmentBaseId);
            return Ok(equipmentBase);
        }

        //NOTE - Removed authorization for testing purposes
        [HttpPost("CreateEquipmentBase")]
        //FIXME - [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateEquipmentBase(EquipmentBaseDto equipmentBaseDto)
        {
            var equipmentBase = await _equipmentBaseService.Create(equipmentBaseDto);
            return Ok(equipmentBase);
        }

        [HttpPut("UpdateEquipmentBase")]
        //FIXME - [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateEquipmentBase(EquipmentBaseDto equipmentBaseDto)
        {
            await _equipmentBaseService.Update(equipmentBaseDto);
            return Ok();
        }

        [HttpDelete("DeleteEquipmentBase")]
        //FIXME - [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteEquipmentBase(int equipmentBaseId)
        {
            await _equipmentBaseService.Delete(equipmentBaseId);
            return Ok();
        }
    }
}

