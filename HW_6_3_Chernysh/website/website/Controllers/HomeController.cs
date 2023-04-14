using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using website.Models;


namespace website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;


        public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _httpClient = factory.CreateClient("myApiClient");
        }

        public async Task<IActionResult> Index()
        {

            HttpResponseMessage booksResponse = await _httpClient.GetAsync("books");


            var booksResponseContent = JsonConvert.DeserializeObject<Book[]>(await booksResponse.Content.ReadAsStringAsync());

            Book[] booksView = booksResponseContent.Select(x => new Book { Id = x.Id, Title = x.Title,
                                                                  Author = x.Author, Description = x.Description }).ToArray();

            var viewTest = View(booksView);

            viewTest.ViewData["Test"] = "ViewDataTest";

            return viewTest;
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

            var json = JsonConvert.SerializeObject(book);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage booksResponse = await _httpClient.PostAsync("books", content);


            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ReadBook()
        {
          

            HttpResponseMessage booksResponse = await _httpClient.GetAsync("books");

            var booksResponseContent = JsonConvert.DeserializeObject<Book[]>(await booksResponse.Content.ReadAsStringAsync());

            Book[] booksView = booksResponseContent.Select(x => new Book
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description
            }).ToArray();


            return View(booksView);
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

            var json = JsonConvert.SerializeObject(book);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage booksResponse = await _httpClient.PutAsync($"books/{book.Id}", content);


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

           

            HttpResponseMessage booksResponse = await _httpClient.DeleteAsync($"books/{id}");


            return View();
        }


    }
    }