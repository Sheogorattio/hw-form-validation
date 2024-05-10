using hw.Models;
using hw.Services;
using hw.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace hw.Controllers{
    public class BookController : Controller
    {
        private readonly BookService _service;

        public BookController(BookService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var books = _service.GetAllBooks();
            return View(books);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    id = Guid.NewGuid(),
                    title = model.title,
                    author = model.author,
                    genre = model.genre,
                    year = model.year
                };

                _service.AddBook(book);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
