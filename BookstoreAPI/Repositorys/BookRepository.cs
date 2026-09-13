namespace BookstoreAPI.Repositorys;
using BookstoreAPI.Entities;

public class BookRepository
{
    private List<Book> books { get; set; } = new();
    
    public void CreateBook(Book book)
    {
        books.Add(book);
    }
    
    public List<Book> GetBooks()
    {
        return books;
    }

    public void UpdateBook(Book book)
    {
        books.Remove(book);
        books.Add(book);
    }

    public Book? GetBookById(Guid Id)
    {
        return books.FirstOrDefault(book => book.Id == Id);
    }

    public void DeleteBook(Book book)
    {
        books.Remove(book);
    }
}