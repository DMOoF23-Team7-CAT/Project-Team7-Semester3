using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.Track;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [ApiController]
    [Route("api/tracks")]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tracks = await _trackService.GetAll();
                return Ok(tracks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
            var track = await _trackService.LoadTrack(id);
            if (track == null)
                return NotFound();

                return Ok(track);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<TrackWithCategoryDto>> GetWithCategory(int id)
        {
            try
            {
                var track = await _trackService.GetTrackWithCategory(id);
                return Ok(track);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrackWithOutIdDto trackDto)
        {
            try
            {
                var track = await _trackService.Create(trackDto);
                return CreatedAtAction(nameof(GetById), new { id = track.Id }, track);
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
        public async Task<IActionResult> Update(int id, [FromBody] TrackWithOutIdDto trackDto)
        {
            try
            {
                await _trackService.Update(trackDto, id);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _trackService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

