using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ShoeShop.Api.Dtos;
using ShoeShop.BLogic.Dtos;
using ShoeShop.Data;
using ShoeShop.Data.Models;

namespace ShoeShop.BLogic
{
    public interface IProductService
    {
        void AddProduct(AddProductRequest request);
        List<Product> GetAllProducts();
        List<Product> GetProductsWithHidden();
        Product GetProductById(Guid id);
        ActionResult UpdateProduct(UpdateProductRequest request);
        ActionResult ArchiveProduct(Guid id);
    }
    
    
    
    public class ProductService : IProductService
    {
        
        private readonly ShoeShopDbContext _context;

        public ProductService()
        {
            _context = new ShoeShopDbContext();
        }

        public void AddProduct(AddProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Where(x => x.Hidden == false).ToList();
        }

        public List<Product> GetProductsWithHidden()
        {
            throw new NotImplementedException(); 
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult UpdateProduct(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }

        public ActionResult ArchiveProduct(Guid id)
        {
            throw new NotImplementedException();
        }
    }
    
    
    
}