using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.Track;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet("GetAllTracks")]
        public async Task<IActionResult> GetTracks()
        {
            var tracks = await _trackService.GetAll();
            return Ok(tracks);
        }

        [HttpGet("GetTrackWithCategory")]
        public async Task<ActionResult<TrackWithCategoryDto>> GetTrackWithCategory(int id)
        {
            var track = await _trackService.GetTrackWithCategory(id);
            return Ok(track);
        }

        [HttpGet("GetTrackWithSigns")]
        public async Task<ActionResult<TrackWithSignsDto>> GetTrackWithSigns(int id)
        {
            var track = await _trackService.GetTrackWithSigns(id);
            return Ok(track);
        }

        [HttpPost("CreateTrack")]
        public async Task<IActionResult> CreateTrack(TrackWithoutIdDto trackDto)
        {
            var track = await _trackService.Create(trackDto);
            return Ok(track);
        }

        [HttpPut("UpdateTrack")]
        public async Task<IActionResult> UpdateTrack(TrackDto trackDto)
        {
            await _trackService.Update(trackDto);
            return Ok();
        }

        [HttpDelete("DeleteTrack")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            await _trackService.Delete(id);
            return Ok();
        }
    }
}

