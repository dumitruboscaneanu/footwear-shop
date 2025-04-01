using System.Data.Entity;
using ShoeShop.Data.Models;

namespace ShoeShop.Data
{
    public class ShoeShopDbContext : DbContext
    {
        public ShoeShopDbContext() : base ("Server=localhost;port=5432;Database=ShoeShop;User Id=postgres;Password=5656;")
        {
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Cart> Carts { get; set; }
        

    }
}