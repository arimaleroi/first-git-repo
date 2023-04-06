using website.Models;

namespace website.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Book_1",
                Author = "Author_1",
                Description = "Description_1",
            },
            new Book
            {
                Id = 2,
                Title = "Book_2",
                Author = "Author_2",
                Description = "Description_2",
            },
            new Book
            {
                Id = 3,
                Title = "Book_3",
                Author = "Author_3",
                Description = "Description_3",
            },
            new Book
            {
                Id = 4,
                Title = "Book_4",
                Author = "Author_4",
                Description = "Description_4",
            },
            new Book
            {
                Id = 5,
                Title = "Book_5",
                Author = "Author_5",
                Description = "Description_5",
            }
        };

        public Task<Book[]> GetBooksAsync()
        {
            return Task.FromResult(_books.ToArray());
        }

        public async Task<Book> GetBookAsync(int id)
        {

            return await Task.FromResult(_books.FirstOrDefault(x => x.Id == id));
        }

        public Task CreateBookAsync(Book book)
        {
            _books.Add(book);
            return Task.CompletedTask;
        }

        public Task UpdateBookAsync(Book updatedBook)
        {

            var book = _books.FirstOrDefault(x => x.Id == updatedBook.Id);

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Description = updatedBook.Description;

            return Task.CompletedTask;

        }

        public Task DeleteBookAsync(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);

            _books.Remove(book);

            return Task.CompletedTask;
        }
    }
}
