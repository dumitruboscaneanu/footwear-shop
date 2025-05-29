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
        List<Product> GetIndex();
        CartItem GetCart(string userName);
        void AddToCart(Guid id, string name);
        void RemoveFromCart(Guid id, string name);
        CartItem Checkout(string userName);
        List<Person> GetUsers();
        Person VerifyUser(string email, string password);
        void Register(Person user);

    }
    
    public class ServiceHandler : IService
    {
        private readonly ShoeShopDbContext _context;
        
        public ServiceHandler()
        {
            _context = new ShoeShopDbContext();
        }
        
        public Person VerifyUser(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
        
        public void Register(Person user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User already exists.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }
        
        public CartItem Checkout(string userName)
        {
            var cart = _context.Carts.FirstOrDefault(x => x.UserName == userName);

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            return cart;
        }
        
        public List<Person> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }
        
        public void AddToCart(Guid id, string name)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            
            var cartItem = new CartItem
            {
                Id = Guid.NewGuid(),
                UserName = name,
                ProductName = product.Name,
                Price = product.Price,
                ProductId = product.Id,
                Quantity = 1,
                ImageUrl = product.ImageUrl
            };

            _context.Carts.Add(cartItem);
            _context.SaveChanges();            
        }

        public void RemoveFromCart(Guid id, string name)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.Id == id && c.UserName == name);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }
        }

        public List<Product> GetIndex()
        {
            var products = _context.Products.Take(3).ToList();
            return products;
        }
        
        public CartItem GetCart(string userName)
        { 
            var cartItems = _context.Carts.FirstOrDefault(x => x.UserName == userName);
            return cartItems;
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