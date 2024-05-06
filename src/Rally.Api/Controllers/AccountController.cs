using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Interfaces;
using Rally.Core.Entities.Account;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("AssignUserRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssignUserRole(string userEmail, string roleName)
    {
        await _accountService.AssignRoleAsync(userEmail, roleName);
        return NoContent();
    }

    [HttpDelete("UnassignUserRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UnassignUserRole(string userEmail, string roleName)
    {
        await _accountService.UnassignRoleAsync(userEmail, roleName);
        return NoContent();
    }
}