using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AiDocumentSearch.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok(new
        {
            status = "Healthy"
        });
    }
}
