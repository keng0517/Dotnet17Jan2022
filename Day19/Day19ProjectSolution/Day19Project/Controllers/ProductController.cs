using Microsoft.AspNetCore.Mvc;
using Day19Project.Models;
using Day19Project.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day19Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<int, Product> _repo;

        public ProductController(IRepo<int, Product> repo)
        {
            _repo = repo;
        }

        //SelectItemList
        IEnumerable<SelectListItem> GetCategories()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Text = "Food", Value = "Food" });
            categories.Add(new SelectListItem { Text = "Toy", Value = "Toy" });
            categories.Add(new SelectListItem { Text = "Clothing", Value = "Clothing" });
            return categories;
        }


        //View Part
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }
        public IActionResult Details(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }


        //Edit Part
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



        //Create Part
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategories();
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



        //Delete Part
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


        //purchasing part
        public IActionResult ProductPurchasing(int id)
        {
            //ViewBag.Category = GetProductCategory();
            //ViewBag.Picture = GetProductPicture();
            Product product = _repo.Get(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult ProductPurchasing(int id, Product product)
        {
            //Product product = _repo.Get(id);

            //product.Quantity = product.Quantity - item.BuyQty;

            _repo.Update(product);

            //if (TempData.ContainsKey("buyQty"))
            //{
            //    TempData.Remove("buyQty");
            //}
            //TempData.Add("buyQty", item.BuyQty);
            //return RedirectToAction("Details", "Product", new { id = product.Id });
            return RedirectToAction("Index");
        }
    }
}
