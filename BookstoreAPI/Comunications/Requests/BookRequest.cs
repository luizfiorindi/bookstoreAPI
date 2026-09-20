using BookstoreAPI.Enums;
namespace BookstoreAPI.Comunications.Requests;

public class BookRequest
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required Genre Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
