using System;

namespace ShoeShop.Data.Models
{
    public class Product
    {
        public Guid Id {get; set; }
        public string Name {get; set; }
        public string Description {get; set; }
        public decimal Price {get; set; }
        public string ImageUrl {get; set; }
        public DateTime CreatedAt {get; set; } = DateTime.UtcNow;
        public bool Hidden {get; set; } = false;
    }
}