using System;
using System.Linq;
using System.Web.Mvc;
using ShoeShop.Models;

namespace ShoeShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShoeShopDbContext _context;

        public AdminController()
        {
            _context = new ShoeShopDbContext();
        }
    
         public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View(_context.Products.ToList());
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Products");
            
        }

        public ActionResult EditProduct(Guid id)
        {   
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
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
            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.Brand = product.Brand;
                    existingProduct.Size = product.Size;
                    existingProduct.Color = product.Color;
                    existingProduct.ImageUrl = product.ImageUrl;
                    existingProduct.InStock = product.InStock;
                    existingProduct.Category = product.Category;
                }
                return RedirectToAction("Products");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Products");
        }
        
        public ActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
        
    }
}