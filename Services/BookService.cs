namespace hw.Services;
using Models;

public class BookService
{
    private readonly List<Book> _books = new();
    
    public IEnumerable<Book> GetAllBooks() => _books;
    public void AddBook(Book book) => _books.Add(book);
}
