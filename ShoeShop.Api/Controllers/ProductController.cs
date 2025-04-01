using System.Web.Mvc;
using ShoeShop.BLogic;
using ShoeShop.BLogic.Dtos;

namespace ShoeShop.Api.Controllers
{
    public class ProductController : Controller
    {
        
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }


        // For admin only in lab 5
        [HttpPost]
        public ActionResult AddProduct(AddProductRequest request)
        {
            if (request.Name != null)
            {
                _productService.AddProduct(request);
            }
            
            return RedirectToAction("GetAllProducts", "Product");
        }
        
        public ActionResult AddProduct()
        {
            var request = new AddProductRequest();
            return View(request);
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