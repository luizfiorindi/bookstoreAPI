using BookstoreAPI.Enums;

namespace BookstoreAPI.Entities;


public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Author { get; private set; } = string.Empty;
    public Genre Genre { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Book(string title, string author, Genre genre, decimal price, int stock)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string title,
        string author,
        Genre genre,
        decimal price,
        int stock)
    {
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        Stock = stock;
        UpdatedAt = DateTime.UtcNow;
    }

    public (bool validated, string? message) Validate()
    {
        if (Price < 0) return (validated: false, message: "Price não pode ser negativo");
        if (Stock < 0) return (validated:false, message: "Stock não pode ser negativo");
        
        return (validated: true, message: null);
    }
}
