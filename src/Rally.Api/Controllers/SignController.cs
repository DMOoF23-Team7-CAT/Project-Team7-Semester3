using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.Sign;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : ControllerBase
    {
        private readonly ISignService _signService;

        public SignController(ISignService signService)
        {
            _signService = signService;     
        }

        [HttpGet("GetAllSigns")]
        public async Task<IActionResult> GetSigns()
        {
            var signs = await _signService.GetAll();
            return Ok(signs);
        }

        [HttpGet("GetSignWithSignBase")]
        public async Task<ActionResult<SignWithSignBaseDto>> GetSignWithSignBase(int id)
        {
            var sign = await _signService.GetSignWithSignBases(id);
            return Ok(sign);
        }

        [HttpGet("GetSignById")]
        public async Task<ActionResult> GetSignById(int id)
        {
            var sign = await _signService.GetById(id);
            return Ok(sign);
        }

        [HttpPost("CreateSign")]
        public async Task<IActionResult> CreateSign(SignWithoutIdDto signDto)
        {
            var sign = await _signService.Create(signDto);
            return Ok(sign);
        }

        [HttpPut("UpdateSign")]
        public async Task<IActionResult> UpdateSign(SignDto signDto)
        {
            await _signService.Update(signDto);
            return Ok();
        }

        [HttpDelete("DeleteSign")]
        public async Task<IActionResult> DeleteSign(int id)
        {
            await _signService.Delete(id);
            return Ok();
        }

    }
}
