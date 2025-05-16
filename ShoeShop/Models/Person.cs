using System;
using System.Collections.Generic;

namespace ShoeShop.Models
{


    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
    
    
    
    
    
    
}  