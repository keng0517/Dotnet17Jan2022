using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleMVCTogetherApp.Models;
using SampleMVCTogetherApp.Services;
using System.Diagnostics;

namespace SampleMVCTogetherApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IAdding<string, User> _adding;
        private readonly IRepo<int, Customer> _repo;

        public UserController(IAdding<string,User> adding,IRepo<int,Customer> repo)
        {
            _adding = adding;
            _repo = repo;
        }
        public IActionResult Register()
        {
            ViewBag.Roles = GetUserRoles();
            return View(new UserCustomer());
        }
        [HttpPost]
        public IActionResult Register(UserCustomer userCustomer)
        {
            if(ModelState.IsValid)
            {
               try
                {
                    Customer customer = new Customer();
                    customer.Name = userCustomer.Name;
                    customer.Age = userCustomer.Age;
                    customer = _repo.Add(customer);
                    User user = new User();
                    user.CustomerId = customer.Id;
                    user.Username = userCustomer.Username;
                    user.Password = userCustomer.Password;
                    user.Role = userCustomer.Role;
                    _adding.Add(user);
                    TempData.Add("un",user.Username);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(userCustomer, ex.Message);
                }

            }
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
           
            return View();
        }
        IEnumerable<SelectListItem> GetUserRoles()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            roles.Add(new SelectListItem { Text = "Admin", Value = "admin" });
            roles.Add(new SelectListItem { Text = "Power User", Value = "power" });
            roles.Add(new SelectListItem { Text = "User", Value = "user" });
            return roles;
        }
    }
}
