using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using AiDocumentSearch.Application.DTOs;

namespace AiDocumentSearch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
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
    public IActionResult GetUsers()
    {
        return Ok(new[]
        {
            new{Id = 1, Name = "Luke"},
            new{Id = 2, Name = "John"}
        });
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
}