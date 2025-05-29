using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoeShop.Models;
using ShoeShop.Services;

namespace ShoeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;

        public HomeController()
        {
            _service = new ServiceHandler();
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        
        public ActionResult Index()
        {
            var products = _service.GetIndex();
            return View(products);
        }

        public ActionResult Products()
        {
            return View(_service.GetAllProducts());
        }

        public ActionResult ProductDetails(Guid id)
        {
            var product = _service.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Cart()
        {
            var cart = _service.GetCart(User.Identity.Name);
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart(Guid id)
        {
            _service.AddToCart(id, User.Identity.Name);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(Guid id)
        {
            _service.RemoveFromCart(id, User.Identity.Name);
            return RedirectToAction("Cart");
        }
        
        public ActionResult Checkout()
        {
            var cart = _service.Checkout(User.Identity.Name);
            
            return View(cart);
        }
        
        
    }
}