using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BookMainController : Controller
{
    [HttpGet("health")]
    public IActionResult Health()
    {
        return Ok("Healthy");
    }
    
}