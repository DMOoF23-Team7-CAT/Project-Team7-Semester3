using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.SignBase;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [Route("api/signbase")]
    [ApiController]
    public class SignBaseController : ControllerBase
    {
        private readonly ISignBaseService _signBaseService;

        public SignBaseController(ISignBaseService signBaseService)
        {
            _signBaseService = signBaseService;                
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSignBases()
        {
            try
            {
                var signBases = await _signBaseService.GetAll();
                return Ok(signBases);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSignBaseById(int id)
        {
            try
            {
                var signBase = await _signBaseService.GetById(id);
                if (signBase == null)
                    return NotFound();

                return Ok(signBase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSignBase([FromBody] SignBaseDto signBaseDto)
        {
            try
            {
                var signBase = await _signBaseService.Create(signBaseDto);
                return CreatedAtAction(nameof(GetSignBaseById), new { id = signBase.Id }, signBase);
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
        public async Task<IActionResult> UpdateSignBase(int id, [FromBody] SignBaseDto signBaseDto)
        {
            try
            {
                await _signBaseService.Update(signBaseDto, id);
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
        public async Task<IActionResult> DeleteSignBase(int id)
        {
            try
            {
                await _signBaseService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
