using Microsoft.AspNetCore.Mvc;
using VivesBlog.Models;
using VivesBlog.Services;

namespace VivesBlog.Mvc.Controllers
{
    public class PersonController : Controller
    {
        private readonly DbService _dbService;

        public PersonController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("People/Index")]
        public IActionResult Index()
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

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }
    }
}
