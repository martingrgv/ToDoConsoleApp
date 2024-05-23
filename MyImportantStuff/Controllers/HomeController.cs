using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyImportantStuff.Models;
using System.Diagnostics;

namespace MyImportantStuff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TodoContext _todoContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _todoContext = new TodoContext();
        }

        public IActionResult Index()
        {
            return View(_todoContext.TodoItems.ToList().OrderBy(t => t.IsCompleted));
        }

        [HttpPost]
        public IActionResult AddTodo(TodoItem todoItem)
        {
            _todoContext.TodoItems.Add(todoItem);
            _todoContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, bool isCompleted)
        {
            _todoContext.TodoItems.FirstOrDefault(t => t.Id == id).IsCompleted = isCompleted;
            _todoContext.SaveChanges();

            return Json(new { redirectTo = "/" });
        }

        [HttpPost]
        public IActionResult DeleteCompleted()
        {
            _todoContext.Database.ExecuteSqlRaw("DELETE FROM [TodoItems] WHERE IsCompleted = 1");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAll()
        {
            _todoContext.Database.ExecuteSqlRaw("TRUNCATE TABLE [TodoItems]");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
