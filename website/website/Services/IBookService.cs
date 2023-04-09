using website.Models;

namespace website.Services
{
    public interface IBookService
    {
        Task<Book[]> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}