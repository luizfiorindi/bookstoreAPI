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
        var removeBook = GetBookById(book.Id);
        if  (removeBook != null)
            books.Remove(removeBook);
        books.Add(book);
    }

    public Book? GetBookById(Guid Id)
    {
        return books.FirstOrDefault(book => book.Id == Id);
    }

    public void DeleteBook(Guid Id)
    {
        var removeBook = GetBookById(Id);
        if  (removeBook != null)
            books.Remove(removeBook);
    }
}