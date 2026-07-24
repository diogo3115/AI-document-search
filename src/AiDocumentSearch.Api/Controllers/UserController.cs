using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("all")]
    public IActionResult GetUsers()
    {
        return Ok(new[]
        {
            new{Id = 1, Name = "Luke"},
            new{Id = 2, Name = "John"}
        });
    }
}