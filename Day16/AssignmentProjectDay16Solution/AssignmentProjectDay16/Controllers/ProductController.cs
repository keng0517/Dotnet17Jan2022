using Microsoft.AspNetCore.Mvc;
using AssignmentProjectDay16.Models;

namespace AssignmentProjectDay16.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> Products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name ="Nike Cap",
                Price = 188.88,
                SupplierId = 1,
                Quantity = 1000,
                Remarks = "One of the top branding in the world."

            },
             new Product()
            {
                Id = 2,
                Name ="Adidas Cap",
                Price = 199.99,
                SupplierId = 1,
                Quantity = 888,
                Remarks = "One of the top branding in the world."
            }
        };
        public IActionResult Index()
        {
            var products = Products;
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            Products.Add(product);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit()
        {            
            return View(new Product());
        }
    }
}
