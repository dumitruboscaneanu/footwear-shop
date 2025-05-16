using System.Data.Entity;
using ShoeShop.Models;

namespace ShoeShop
{
    public class ShoeShopDbContext : DbContext
    {
        
        public ShoeShopDbContext() : base("name=ShoeShopDbContext")
        {
        }

        public DbSet<CartItem> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Users { get; set; }
    }
}