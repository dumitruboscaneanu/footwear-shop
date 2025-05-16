using System;

namespace ShoeShop.Models
{
    public class CartItem
    {
        public Guid Id { get; set;} = Guid.NewGuid();
        public string UserName { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public decimal Price { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public string ImageUrl { get; set; } = "";
    }
}