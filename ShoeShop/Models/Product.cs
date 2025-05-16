using System;
using System.ComponentModel.DataAnnotations;

namespace ShoeShop.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }
    }
}