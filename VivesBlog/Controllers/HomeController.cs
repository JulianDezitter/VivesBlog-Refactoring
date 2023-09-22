using Microsoft.AspNetCore.Mvc;
using VivesBlog.Services;

namespace VivesBlog.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVivesBlogDbService _vivesBlogDbService;

        public HomeController(IVivesBlogDbService service)
        {
            _vivesBlogDbService = service;
        }

        public IActionResult Index()
        {
            var articles = _vivesBlogDbService.GetArticles();
            return View(articles);
        }
    }
}
