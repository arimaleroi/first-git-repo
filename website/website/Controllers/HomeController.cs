using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using website.Models;
using website.Services;

namespace website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BookService _bookService;

        public HomeController(ILogger<HomeController> logger, BookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(int id, string title, string author, string description)
        {
            var book = new Book
            {
                Id = id,
                Title = title,
                Author = author,
                Description = description

            };

            await _bookService.CreateBookAsync(book);
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> ReadBook()
        {
            var books = await _bookService.GetBooksAsync();

            return View(books);
        }

        [HttpGet]
        public IActionResult UpdateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(int id, string title, string author, string description)
        {
            var book = new Book
            {
                Id = id,
                Title = title,
                Author = author,
                Description = description

            };

            await _bookService.UpdateBookAsync(book);
            return View();
        }

        [HttpGet]
        public IActionResult DeleteBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return View();
        }




    }
}