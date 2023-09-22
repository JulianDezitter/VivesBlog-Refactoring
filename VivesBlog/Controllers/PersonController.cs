using Microsoft.AspNetCore.Mvc;
using VivesBlog.Models;
using VivesBlog.Services;

namespace VivesBlog.Mvc.Controllers
{
    public class PersonController : Controller
    {
        private readonly IVivesBlogDbService _vivesBlogDbService;

        public PersonController(IVivesBlogDbService vivesBlogDbService)
        {
            _vivesBlogDbService = vivesBlogDbService;
        }

        [HttpGet("People/Index")]
        public IActionResult Index()
        {
            var people = _vivesBlogDbService.GetPeople();
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
            _vivesBlogDbService.AddPerson(person);

            return RedirectToAction("Index");
        }

        [HttpGet("People/Edit/{id}")]
        public IActionResult PeopleEdit(int id)
        {
            var person = _vivesBlogDbService.GetPerson(id);

            return View(person);
        }

        [HttpPost("People/Edit/{id}")]
        public IActionResult PeopleEdit(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            _vivesBlogDbService.UpdatePerson(id, person);

            return RedirectToAction("Index");
        }

        [HttpGet("People/Delete/{id}")]
        public IActionResult PeopleDelete(int id)
        {
            var person = _vivesBlogDbService.GetPerson(id);

            return View(person);
        }

        [HttpPost("People/Delete/{id}")]
        public IActionResult PeopleDeleteConfirmed(int id)
        {
            _vivesBlogDbService.DeletePerson(id);

            return RedirectToAction("Index");
        }
    }
}
