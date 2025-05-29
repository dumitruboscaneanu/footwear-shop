using System;
using System.Linq;
using System.Web.Mvc;
using ShoeShop.Models;
using ShoeShop.Services;

namespace ShoeShop.Controllers
{
    public class AdminController : Controller
    {

        private readonly IService _service;
        
        public AdminController()
        {
            _service = new ServiceHandler();
        }
    
         public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View(_service.GetAllProducts());
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            
            _service.AddProduct(product);
            return RedirectToAction("Products");
            
        }

        public ActionResult EditProduct(Guid id)
        {   
            var product = _service.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(Product product)
        {
            _service.UpdateProduct(product);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(Guid id)
        {
            _service.DeleteProduct(id);
            return RedirectToAction("Products");
        }
        
        public ActionResult GetUsers()
        {
            var users = _service.GetUsers();
            return View(users);
        }
        
    }
}