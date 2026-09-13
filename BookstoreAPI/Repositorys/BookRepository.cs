namespace BookstoreAPI.Repositorys;
using BookstoreAPI.Entities;

public class BookRepository
{
    private List<Book> books { get; set; }
    
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

    public Book GetBookById(string Id)
    {
        foreach (var book in books)
        {
            if (book.Id.ToString() == Id)
                return book;
        }
        
        return null;
    }

    public void DeleteBook(Book book)
    {
        books.Remove(book);
    }
}