using Microsoft.AspNetCore.Mvc;

namespace VivesBlog.Controllers
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

        public IActionResult Details(int id)
        {
            var article = _dbService.GetArticle(id);

            return View(article);
        }

        [HttpGet("People/Index")]
        public IActionResult PeopleIndex()
        {
            var people = _dbService.GetPeople();
            return View(people);
        }

        [HttpGet("People/Create")]
        public IActionResult PeopleCreate()
        {
            return View();
        }

        [HttpPost("People/Create")]
        public IActionResult PeopleCreate(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            _dbService.AddPerson(person);

            return RedirectToAction("PeopleIndex");
        }

        [HttpGet("People/Edit/{id}")]
        public IActionResult PeopleEdit(int id)
        {
            var person = _dbService.GetPerson(id);

            return View(person);
        }

        [HttpPost("People/Edit/{id}")]
        public IActionResult PeopleEdit(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            _dbService.UpdatePerson(id, person);

            return RedirectToAction("PeopleIndex");
        }

        [HttpGet("People/Delete/{id}")]
        public IActionResult PeopleDelete(int id)
        {
            var person = _dbService.GetPerson(id);

            return View(person);
        }

        [HttpPost("People/Delete/{id}")]
        public IActionResult PeopleDeleteConfirmed(int id)
        {
            _dbService.DeletePerson(id);

            return RedirectToAction("PeopleIndex");
        }

        [HttpGet("Blog/Index")]
        public IActionResult BlogIndex()
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

            return RedirectToAction("BlogIndex");
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

            return RedirectToAction("BlogIndex");
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

            return RedirectToAction("BlogIndex");
        }

        private ArticleModel CreateArticleModel(Article article = null)
        {
            article ??= new Article();

            var authors = _dbService.GetPeopleOrderd();

            var articleModel = new ArticleModel
            {
                Article = article,
                Authors = authors
            };

            return articleModel;
        }
    }
}
