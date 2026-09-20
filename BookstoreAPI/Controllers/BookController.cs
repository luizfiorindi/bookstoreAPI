using BookstoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using BookstoreAPI.Comunications.Requests;
using BookstoreAPI.Comunications.Responses;
using BookstoreAPI.Enums;
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
                Id =  book.Id,
                Title =  book.Title,
                Author = book.Author,
                Price = book.Price,
                Stock = book.Stock,
            };
            response.Add(bookResponse);
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BookModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBook([FromRoute] Guid id)
    {
        var listBooks = new ListBooks(BookRepository);
        var book = listBooks.GetBookById(id);
        if (book is null)
            return NotFound();
        var response = new GetBookResponse
        {
            Id = book.Id,
            Title = book.Title,
            Author =  book.Author,
            Price = book.Price,
            Stock = book.Stock,
            
        };
        return Ok(response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(UpdatedBookResponse), StatusCodes.Status400BadRequest)]
    public IActionResult UpdateBook([FromRoute] Guid id, [FromBody] BookRequest request)
    {
        var bookModel = new BookModel
        {
            Id = id,
            Title = request.Title,
            Author = request.Author,
            Price = request.Price,
            Stock = request.Stock,
        };

        var updateBook = new UpdateBook(BookRepository);
        var listBook = new ListBooks(BookRepository);
        if (listBook.GetBookById(id) is null)
            return NotFound();
        var updatedBook = updateBook.Execute(bookModel);
        if (updatedBook.Updated) return NoContent();
        var response = new UpdatedBookResponse
        {
            ErrorMessage = updatedBook.ErrorMessage ?? ""
        };
        return BadRequest(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteBook([FromRoute] Guid id)
    {
        var deleteBook = new DeleteBook(BookRepository);
        var deletedBook = deleteBook.Execute(id);
        if (deletedBook.deleted) return NoContent();
        return NotFound();
    }

    [HttpGet("Genres")]
    [ProducesResponseType(typeof(List<GenreResponse>), StatusCodes.Status200OK)]
    public IActionResult GetGenres()
    {
        var response = new List<GenreResponse>();
        foreach (var genre in Enum.GetValues<Genre>())
        {
            var genreResponse = new GenreResponse
            {
                Id = (int)genre,
                Name = genre.ToString()
            };
            
            response.Add(genreResponse);
        }
        
        return Ok(response);
    }
}
