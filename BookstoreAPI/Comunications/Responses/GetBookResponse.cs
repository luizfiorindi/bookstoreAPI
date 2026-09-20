using BookstoreAPI.Enums;

namespace BookstoreAPI.Comunications.Responses;

public class GetBookResponse
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
