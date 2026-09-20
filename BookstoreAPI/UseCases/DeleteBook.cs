using BookstoreAPI.Repositorys;

namespace BookstoreAPI.UseCases;

public class DeleteBook
{
    private BookRepository repository { get; set; }
    
    public DeleteBook(BookRepository repository)
    {
        this.repository = repository;
    }

    public (bool deleted, string? errorMessage) Execute(Guid Id)
    {
        var deleteBook = repository.GetBookById(Id);
        if (deleteBook is null) return (false, "Livro nao encontrado");
        repository.DeleteBook(Id);
        return (true, null);
    }
}