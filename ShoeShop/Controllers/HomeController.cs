using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoeShop.Models;

namespace ShoeShop.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ShoeShopDbContext _context;

        public HomeController()
        {
            _context = new ShoeShopDbContext();
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
            var featuredProducts = _context.Products.Take(3).ToList();
            return View(featuredProducts);
        }

        public ActionResult Products()
        {
            return View(_context.Products.ToList());
        }

        public ActionResult ProductDetails(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Cart()
        {
            var cart = _context.Carts.FirstOrDefault(x => x.UserName == User.Identity.Name);
            return View(cart);
        }

        [HttpPost]
        public ActionResult AddToCart(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            
            var cartItem = new CartItem
            {
                Id = Guid.NewGuid(),
                UserName = User.Identity.Name,
                ProductName = product.Name,
                Price = product.Price,
                ProductId = product.Id,
                Quantity = 1,
                ImageUrl = product.ImageUrl
            };

            _context.Carts.Add(cartItem);
            _context.SaveChanges();            
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(Guid id)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public ActionResult UpdateCart(Guid id, int quantity)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cartItem != null)
            {
                if (quantity <= 0)
                {
                    _context.Carts.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity = quantity;
                }
            }
            return RedirectToAction("Cart");
        }
        
        
        
        public ActionResult Checkout()
        {
            var cart = _context.Carts.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (cart == null)
            {
                return HttpNotFound();
            }

            _context.Carts.Remove(cart);
            _context.SaveChanges();
            
            return View(cart);
        }
        
        
    }
}