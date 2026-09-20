using BookstoreAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BookMainController : Controller
{
    protected BookRepository bookRepository = new BookRepository();
    
    [HttpGet("health")] 
    public IActionResult Health()
    {
        return Ok("Healthy");
    }
}