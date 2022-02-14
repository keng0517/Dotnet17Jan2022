using Day19Project.Models;

namespace Day19Project.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        private readonly ShopContext _context;
        //Takingthe context object as injection

        public ProductRepo(ShopContext context)
        {
            _context = context;
        }
        public bool Add(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
            return true;
        }

        public Product Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public bool Remove(int id)
        {
            Product product = Get(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Product item)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == item.Id);
            if (product != null)
            {
                product.Name = item.Name;
                product.Description = item.Description;
                product.Price = item.Price;
                product.Pic = item.Pic;
                _context.Products.Update(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

