using HW_6_1_Chernysh.Models;

namespace HW_6_1_Chernysh.Core
{
    public interface IBookRepository
    {
        public Task<Book[]> GetBooksAsync();
        public Task<Book> GetBookAsync(int id);
        public Task CreateBookAsync(Book book);
        public Task UpdateBookAsync(int id, Book updatedBook);
        public Task DeleteBookAsync(int id);


    }
}
