using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rally.Application.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("assign-user-role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignUserRole(string userEmail, string roleName)
    {
        try
        {
            await _accountService.AssignRoleAsync(userEmail, roleName);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("unassign-user-role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UnassignUserRole(string userEmail, string roleName)
    {
        try
        {
            await _accountService.UnassignRoleAsync(userEmail, roleName);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _accountService.LogoutAsync();
        return Ok(new { message = "Logged out successfully" });
    }
}
