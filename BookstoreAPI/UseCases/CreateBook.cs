using BookstoreAPI.Entities;
using BookstoreAPI.Models;
using BookstoreAPI.Repositorys;

namespace BookstoreAPI.UseCases;

public class CreateBook
{
    private BookRepository repository { get; set; }

    public CreateBook(BookRepository repository)
    {
        this.repository = repository;
    }
    
    public (bool created, string? message) Execute(BookModel bookModel)
    {
        var createdBooks = repository.GetBooks();
        
        if (createdBooks.Any(book => book.Title == bookModel.Title && book.Author == bookModel.Author)) 
            return (created: false, message: "Livro já existe");
        
        var newBook = new Book(
            title: bookModel.Title, 
            author: bookModel.Author, 
            genre: bookModel.Genre, 
            price: bookModel.Price, 
            stock: bookModel.Stock
            );

        var validatedBook = newBook.Validate();

        if (!validatedBook.validated)
            return (created: false, message: validatedBook.message);
        
        repository.CreateBook(newBook);
        
        return (created: true, message: null);
    }
}