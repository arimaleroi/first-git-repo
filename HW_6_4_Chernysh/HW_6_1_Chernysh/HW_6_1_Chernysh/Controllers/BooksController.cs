using HW_6_1_Chernysh.Core;
using HW_6_1_Chernysh.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HW_6_1_Chernysh.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {

            _bookRepository = bookRepository;
        }

        // GET: api/<BooksController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok(await _bookRepository.GetBooksAsync());
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<Book> GetBookAsync(int id)
        {
            return await _bookRepository.GetBookAsync(id);
        }

        // POST api/<BooksController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBookAsync([FromBody] Book book)
        {
            await _bookRepository.CreateBookAsync(book);
            return StatusCode(201);
        }

        // PUT api/<BooksController>/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] Book updatedBook)
        {
            await _bookRepository.UpdateBookAsync(id, updatedBook);
            return StatusCode(200);
        }

        // DELETE api/<BooksController>/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsyncId(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return NoContent();
        }

        
    }
}
