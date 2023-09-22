using Microsoft.AspNetCore.Mvc;
using VivesBlog.Models;
using VivesBlog.Services;

namespace VivesBlog.Mvc.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IVivesBlogDbService _dbService;

        public ArticleController(IVivesBlogDbService dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Details(int id)
        {
            var article = _dbService.GetArticle(id);

            return View(article);
        }

        [HttpGet("Blog/Index")]
        public IActionResult Index()
        {
            var articles = _dbService.GetArticles();
            return View(articles);
        }

        [HttpGet("Blog/Create")]
        public IActionResult BlogCreate()
        {
            var articleModel = CreateArticleModel();

            return View(articleModel);
        }

        [HttpPost("Blog/Create")]
        public IActionResult BlogCreate(Article article)
        {
            if (!ModelState.IsValid)
            {
                var articleModel = CreateArticleModel(article);
                return View(articleModel);
            }

            _dbService.AddArticle(article);

            return RedirectToAction("Index");
        }

        [HttpGet("Blog/Edit/{id}")]
        public IActionResult BlogEdit(int id)
        {
            var article = _dbService.GetArticle(id);

            var articleModel = CreateArticleModel(article);

            return View(articleModel);
        }

        [HttpPost("Blog/Edit/{id}")]
        public IActionResult BlogEdit(int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                var articleModel = CreateArticleModel(article);
                return View(articleModel);
            }

            _dbService.UpdateArticle(id, article);

            return RedirectToAction("Index");
        }

        [HttpGet("Blog/Delete/{id}")]
        public IActionResult BlogDelete(int id)
        {
            var article = _dbService.GetArticle(id);

            return View(article);
        }

        [HttpPost("Blog/Delete/{id}")]
        public IActionResult BlogDeleteConfirmed(int id)
        {
            _dbService.DeleteArticle(id);

            return RedirectToAction("Index");
        }

        private ArticleModel CreateArticleModel(Article? article = null)
        {
            article ??= new Article();

            var authors = _dbService.GetPeopleOrdered();

            var articleModel = new ArticleModel
            {
                Article = article,
                Authors = authors
            };

            return articleModel;
        }
    }
}
