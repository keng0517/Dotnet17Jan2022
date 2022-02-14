using Microsoft.AspNetCore.Mvc;
using Day19Project.Models;
using Day19Project.Services;

namespace Day19Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;

        public ProductController(IRepo<int, Product> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }
        public IActionResult Details(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        public IActionResult Edit(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            _repo.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        public IActionResult Delete(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
