using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using AiDocumentSearch.Application.DTOs;
using AiDocumentSearch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace AiDocumentSearch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    public readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var userId = Guid.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        var user = await _context.Users.FindAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(new{
            user.Id,
            user.Email,
            user.CreatedAt
        });
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile(UpdateUserRequest request)
    {
        var email = request.Email.Trim().ToLower();

        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        var user = await _context.Users.FindAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }
        var emailExists = await _context.Users.AnyAsync(
            u => u.Email == email && u.Id != userId
        );

        if (emailExists)
        {
            return Conflict("Email in use.");
        }

        user.Email = email;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            Message = "Profile updated succefully",
            user.Id,
            user.Email
        });
    }

    [HttpDelete("profile")]
    public async Task<IActionResult> DeleteProfile()
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );
        var user = await _context.Users.FindAsync(userId);
        
        if (user == null)
        {
            return NotFound("User not found.");
        }

        _context.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}