using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using AiDocumentSearch.Application.DTOs;

namespace AiDocumentSearch.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterUserRequest request)
    {
        return Ok(new
        {
            Message = "User registered successfully",
            Email = request.Email
        });
    }
}