using BookstoreAPI.Entities;

namespace BookstoreAPI.Comunications.Responses;

public class CreatedBookResponse
{
    public string? Message { get; set; }
    public bool Created { get; set; }
}