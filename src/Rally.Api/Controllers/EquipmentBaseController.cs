using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.Category;
using Rally.Application.Dto.EquipmentBase;
using Rally.Application.Dto.SignBase;
using Rally.Application.Interfaces;
using Rally.Application.Services;

namespace Rally.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentBaseController : ControllerBase
    {
        private readonly IEquipmentBaseService _equipmentBaseService;

        public EquipmentBaseController(IEquipmentBaseService equipmentBaseService)
        {
            _equipmentBaseService = equipmentBaseService;
        }

        [HttpGet("GetAllEquipmentBases")]
        public async Task<IActionResult> GetEquipmentbases()
        {
            var equimentbases = await _equipmentBaseService.GetAll();
            return Ok(equimentbases);
        }

        [HttpGet("GetEquipmentBaseById")]
        public async Task<IActionResult> GetEquipmentBaseById(int equipmentBaseId)
        {
            var equimentbase = await _equipmentBaseService.GetById(equipmentBaseId);
            return Ok(equimentbase);
        }

        [HttpPost("CreateEquipmentBase")]
        public async Task<IActionResult> CreateEquipmentBase(EquipmentBaseDto equipmentBaseDto)
        {
            var equipmentBase = await _equipmentBaseService.Create(equipmentBaseDto);
            return Ok(equipmentBase);
        }

        [HttpPut("UpdateEquipmentBase")]
        public async Task<IActionResult> UpdateEquipmentBase(EquipmentBaseDto equipmentBaseDto)
        {
            await _equipmentBaseService.Update(equipmentBaseDto);
            return Ok();
        }

        [HttpDelete("DeleteEquipmentBase")]
        public async Task<IActionResult> DeleteEquipmentBase(int id)
        {
            await _equipmentBaseService.Delete(id);
            return Ok();
        }
    }
}
