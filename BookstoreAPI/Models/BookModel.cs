using System.Text.Json;
using System.Text.Json.Serialization;
using BookstoreAPI.Entities;
using BookstoreAPI.Enums;

namespace BookstoreAPI.Models;

public class BookModel
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public static BookModel FromJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            throw new ArgumentException("O JSON não pode estar vazio.", nameof(json));

        return JsonSerializer.Deserialize<BookModel>(json, JsonOptions)
            ?? throw new JsonException("Não foi possível converter o JSON para BookModel.");
    }

    public static string ToJson(Book book)
    {
        ArgumentNullException.ThrowIfNull(book);

        return JsonSerializer.Serialize(book, JsonOptions);
    }
}
