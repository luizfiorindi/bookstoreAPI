using BookstoreAPI.Enums;

namespace BookstoreAPI.Entities;


public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public Genre Genre { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Book(Guid? Id, string title, string author, Genre genre, decimal price, int stock)
    {
        this.Id = Id ?? Guid.NewGuid();
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        Stock = stock;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public (bool validated, string? message) Validate()
    {   
        if (Title.Length < 3 || Title.Length > 120) 
            return (false, "Título deve ter entre 3 e 120 caracteres");
        if (Author.Length < 3 || Author.Length > 120)
            return (false, "Autor deve ter entre 3 e 120 caracteres");
        if (!Enum.IsDefined(typeof(Enums.Genre), Genre)) 
            return (false, "O gênero informado é inválido");
        if (Price < 0) return ( false, "Price não pode ser negativo");
        if (Stock < 0) return (false, "Stock não pode ser negativo");
        
        return (validated: true, message: null);
    }
}
