﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Dto.SignBase;
using Rally.Application.Interfaces;

namespace Rally.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignBaseController : ControllerBase
    {
        private readonly ISignBaseService _signBaseService;

        public SignBaseController(ISignBaseService signBaseService)
        {
            _signBaseService = signBaseService;                
        }

        [HttpGet("GetAllSignBases")]
        public async Task<IActionResult> GetSignBases()
        {
            var signBases = await _signBaseService.GetAll();
            return Ok(signBases);
        }

//FIXME - Delete this method trough the stack. there is already get Category with sign bases method in category
        [HttpGet("GetSignBaseWithCategory")]
        public async Task<IActionResult> GetSignBaseWithCategory(int signBaseId)
        {
            var signBases = await _signBaseService.GetSignBaseWithCategory(signBaseId);
            return Ok(signBases);
        }

        [HttpGet("GetSignBaseById")]
        public async Task<ActionResult> GetSignBaseById(int id)
        {
            var signBase = await _signBaseService.GetById(id);
            return Ok(signBase);
        }

        //NOTE - Removed authorization for testing purposes
        [HttpPost("CreateSignBase")]
        //FIXME - [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> CreateSignBase(SignBaseDto signBaseDto)
        {
            var signBase = await _signBaseService.Create(signBaseDto);
            return Ok(signBase);
        }

        [HttpPut("UpdateSignBase")]
        //FIXME - [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateSignBase(SignBaseDto signBaseDto)
        {
            await _signBaseService.Update(signBaseDto);
            return Ok();
        }

        [HttpDelete("DeleteSignBase")]
        //FIXME - [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteSignBase(int id)
        {
            await _signBaseService.Delete(id);
            return Ok();
        }

    }
}
