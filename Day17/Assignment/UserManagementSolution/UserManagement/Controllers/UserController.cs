using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepo<int, User> _repo;

        public UserController(IRepo<int, User> repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var users = _repo.GetAll();
            return View(users);
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var user = _repo.GetT(id);
            return View(user);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _repo.GetT(id);
            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            _repo.Update(id, user);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _repo.Add(user);
            return RedirectToAction("Index");
        }
    }
}
