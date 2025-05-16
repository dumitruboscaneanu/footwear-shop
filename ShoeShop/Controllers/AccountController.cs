using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShoeShop.Dto;
using ShoeShop.Models;

namespace ShoeShop.Controllers
{
    

    public class AccountController : Controller
    {
        private readonly ShoeShopDbContext _context;
        
        public AccountController()
        {
            _context = new ShoeShopDbContext();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    var authTicket = new FormsAuthenticationTicket(
                        1, 
                        user.Name, 
                        DateTime.Now, 
                        DateTime.Now.AddMinutes(30),
                        model.RememberMe,
                        user.IsAdmin ? "Admin" : "User"
                    );
                    
                    var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    {
                        HttpOnly = true,
                        Expires = model.RememberMe ? DateTime.Now.AddDays(7) : DateTime.MinValue
                    };

                    Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid email or password.");
            }
            return View(model);
        }
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email used");
                    return View(model);
                }

                var newUser = new Person
                {
                    Id = Guid.NewGuid(),
                    Name = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    IsAdmin = false
                };
                
                _context.Users.Add(newUser);
                _context.SaveChanges();
                FormsAuthentication.SetAuthCookie(newUser.Name, false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    }
}