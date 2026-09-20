using BookstoreAPI.Entities;
using BookstoreAPI.Models;
using BookstoreAPI.Repositorys;

namespace BookstoreAPI.UseCases;

public class UpdateBook
{
    private BookRepository repository { get; set; }

    public UpdateBook(BookRepository repository)
    {
        this.repository = repository;
    }

    public (bool Updated, string? ErrorMessage) Execute(BookModel bookModel)
    {
        var createdBooks = repository.GetBooks();
        
        var updatedBook = new Book(
            Id: bookModel.Id,
            title: bookModel.Title, 
            author: bookModel.Author, 
            genre: bookModel.Genre, 
            price: bookModel.Price, 
            stock: bookModel.Stock
        );
        updatedBook.Update();
        
        var validatedBook = updatedBook.Validate();

        if (!validatedBook.validated)
            return (Updated: false, ErrorMessage: validatedBook.message);
        
        repository.UpdateBook(updatedBook);
        return (Updated: true,  ErrorMessage: null);
    }
}