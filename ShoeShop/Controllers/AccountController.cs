using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ShoeShop.Dto;
using ShoeShop.Models;
using ShoeShop.Services;

namespace ShoeShop.Controllers
{
    

    public class AccountController : Controller
    {
        private readonly IService _service;
        
        public AccountController()
        {
            _service = new ServiceHandler();
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
                var user = _service.VerifyUser(model.Email, model.Password);
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
            
            var newUser = new Person
            {
                Id = Guid.NewGuid(),
                Name = model.Username,
                Email = model.Email,
                Password = model.Password,
                IsAdmin = false
            };
            
            _service.Register(newUser);
            
            FormsAuthentication.SetAuthCookie(newUser.Name, false);
            return RedirectToAction("Index", "Home");
            
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    }
}