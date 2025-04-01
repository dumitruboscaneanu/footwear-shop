using System;
using System.Collections.Generic;

namespace ShoeShop.Data.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; } = 0;
    }
}