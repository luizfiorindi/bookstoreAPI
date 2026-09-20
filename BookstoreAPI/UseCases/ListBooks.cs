using BookstoreAPI.Models;
using BookstoreAPI.Repositorys;

namespace BookstoreAPI.UseCases;

public class ListBooks
{
    private BookRepository repository { get; }

    public ListBooks(BookRepository repository)
    {
        this.repository = repository;
    }
    
    public List<BookModel> GetBooks ()
    {
        var books = repository.GetBooks();
        var booksModel = new List<BookModel>();
        if (books.Count > 0)
        {
            foreach (var book in  books)
            {
                var bookModel = new BookModel
                {
                    Title =  book.Title,
                    Author = book.Author,
                    Price = book.Price,
                    Stock =  book.Stock,
                    Genre =  book.Genre
                };
                booksModel.Add(bookModel);
            }
        }
        
        return booksModel;
    }
}