using HW_6_1_Chernysh.Core;
using HW_6_1_Chernysh.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_6_1_Chernysh.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _bookRepository;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<Book[]> GetBooksAsync()
        {
            return await _bookRepository.GetBooksAsync();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<Book> GetBookAsync(int id)
        {
            return await _bookRepository.GetBookAsync(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task CreateBookAsync([FromBody] Book book)
        {
            await _bookRepository.CreateBookAsync(book);
        }
        
        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task UpdateBookAsync(int id, [FromBody] Book updatedBook)
        {
            await _bookRepository.UpdateBookAsync(id, updatedBook);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }
        
    }
}
