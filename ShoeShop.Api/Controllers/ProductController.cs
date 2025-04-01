using System.Web.Mvc;
using ShoeShop.Api.Dtos;
using ShoeShop.Data.Models;

namespace ShoeShop.Api.Controllers
{
    public class ProductController : Controller
    {

        // For admin only in lab 5
        [HttpPost]
        public ActionResult AddProduct(AddProductRequest request)
        {
            if (request.Name != null)
            {
                var product = new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price
                };
                // Save product to database
            }
            
            return RedirectToAction("GetAllProducts", "Product");
        }
        
        public ActionResult AddProduct()
        {
            // in lab 4
            return View();
        }
        
        // admin only lab5
        public ActionResult GetProductsWithHidden()
        {
            // logic for Get all products from database (all)
            // in lab 4
            return View();
        }
        
        public ActionResult GetAllProducts(string id)
        {
            // Get product by id from database (only hidden = false)
            // in lab 4
            return View();
        }
        
        
    }
}