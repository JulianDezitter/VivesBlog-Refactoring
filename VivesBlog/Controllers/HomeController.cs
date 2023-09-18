using Microsoft.AspNetCore.Mvc;
using VivesBlog.Models;
using VivesBlog.Services;

namespace VivesBlog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbService _dbService;

        public HomeController(DbService service)
        {
            _dbService = service;
        }

        public IActionResult Index()
        {
            var articles = _dbService.GetArticles();
            return View(articles);
        }
    }
}
