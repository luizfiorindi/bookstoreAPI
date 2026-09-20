using BookstoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BookstoreAPI.Comunications.Requests;
using BookstoreAPI.Comunications.Responses;
using BookstoreAPI.Repositorys;
using BookstoreAPI.UseCases;
namespace BookstoreAPI.Controllers;

public class BookController : BookMainController
{
    public BookController(BookRepository bookRepository) : base(bookRepository)
    {
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreatedBookResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CreatedBookResponse), StatusCodes.Status400BadRequest)]
    public IActionResult CreateBook([FromBody] BookRequest request)
    {
        var bookModel = new BookModel
        {
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
            Title = request.Title
        };
        
        var createBook = new CreateBook(BookRepository);
        var createReturn = createBook.Execute(bookModel);
        var response = new CreatedBookResponse
        {
            Created = createReturn.created,
            Message = createReturn.message
        };
        
        if (!response.Created) return BadRequest(response);

        return Created("",response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetBookResponse>), StatusCodes.Status200OK)]
    public IActionResult GetBooks ()
    {
        var listbooks = new ListBooks(BookRepository);
        var books = listbooks.GetBooks();
        var response = new List<GetBookResponse>();
        foreach (var book in books)
        {
            var bookResponse = new GetBookResponse
            {
                Title =  book.Title,
                Author = book.Author,
                Price = book.Price,
                Stock = book.Stock,
            };
            response.Add(bookResponse);
        }
        return Ok(response);
    }
}
