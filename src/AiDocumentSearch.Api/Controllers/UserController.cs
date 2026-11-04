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
public class UserController : ControllerBase
{
    public readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        return Ok(new{
            Id = id,
            Name = "John Smith",
            Email = "JohnSmith@email.com"
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users.ToListAsync();

        return Ok(users);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UpdateUserRequest request)
    {
        var user = new
        {
            Id = id,
            Name = request.Name,
            Email = request.Email
        };

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        return NoContent();
    }
    
    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var email = User.FindFirst(ClaimTypes.Email)?.Value;

        return Ok(new
        {
            Message = "You are authenticated!",
            UserId = userId,
            Email = email
        });
    }
}