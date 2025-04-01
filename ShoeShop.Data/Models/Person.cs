using System.Collections.Generic;

namespace ShoeShop.Data.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Cart> Carts { get; set; }
    }
}