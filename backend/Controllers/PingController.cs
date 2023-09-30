using Microsoft.AspNetCore.Mvc;

namespace ItemsCrud.Controllers;

[ApiController]
[Route("ping")]
public class PingController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Ping()
    {
        return Ok(DateTime.UtcNow.ToString());
    }
}