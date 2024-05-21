using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.Sign;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [Authorize]
    [Route("api/Sign")]
    [ApiController]
    public class SignController : ControllerBase
    {
        private readonly ISignService _signService;

        public SignController(ISignService signService)
        {
            _signService = signService;     
        }

        [HttpGet()]
        public async Task<IActionResult> GetSigns()
        {
            try
            {
                var signs = await _signService.GetAll();
                return Ok(signs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<SignWithSignBaseDto>> GetSignWithSignBase(int id)
        {
            try
            {
                var sign = await _signService.GetSignWithSignBases(id);
                if (sign == null)
                    return NotFound();

                return Ok(sign);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSignById(int id)
        {
            try
            {
                var sign = await _signService.GetById(id);
                if (sign == null)
                    return NotFound();

                return Ok(sign);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateSign([FromBody] SignWithoutIdDto signDto)
        {
            try
            {
                var sign = await _signService.Create(signDto);
                return CreatedAtAction(nameof(GetSignById), new { id = sign.Id }, sign);
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
        public async Task<IActionResult> UpdateSign(int id, [FromBody] SignWithoutIdDto signDto)
        {
            try
            {
                await _signService.Update(signDto, id);
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
        public async Task<IActionResult> DeleteSign(int id)
        {
            try
            {
                await _signService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
