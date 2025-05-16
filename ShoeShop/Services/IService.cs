using System;
using System.Collections.Generic;
using System.Linq;
using ShoeShop.Models;

namespace ShoeShop.Services
{
    public interface IService
    {
        List<Product> GetAllProducts();
        Product GetProductById(Guid id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);
        
    }
    
    public class ServiceHandler : IService
    {
        private readonly ShoeShopDbContext _context;
        
        public ServiceHandler(ShoeShopDbContext context)
        {
            _context = context;
        }


        public List<Product> GetAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public Product GetProductById(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new System.ArgumentNullException(nameof(product));
            }

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new System.ArgumentNullException(nameof(product));
            }

            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.ImageUrl = product.ImageUrl;
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
    
    
    
    
}