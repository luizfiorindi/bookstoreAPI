using BookstoreAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class BookMainController : Controller
{
    protected BookRepository BookRepository { get; }

    protected BookMainController(BookRepository bookRepository)
    {
        BookRepository = bookRepository;
    }
    
    [HttpGet("health")] 
    public IActionResult Health()
    {
        return Ok("Healthy");
    }
}
