using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    [Serializable]
    public class Product
    {
        public Product(string name, string fullName, int price, string image, string description, string country)
        {
            Name = name;
            FullName = fullName;
            Price = price;
            Image = image;
            Description = description;
            Country = country;
        }
        public Product()
        {
            Name = "None";
            FullName = "None";
            Price = -1;
            Image = "None";
            Description = "None";
            Country = "None";
        }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
